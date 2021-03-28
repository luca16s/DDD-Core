// -----------------------------------------------------------------------
// <copyright file="BaseContext.cs" company="DeadFish Studio">
// Copyright (c) DeadFish Studio. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace CoreLibrary
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    using System;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Base Context Class.
    /// </summary>
    public class BaseContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction? currentTransaction;

        /// <summary>
        /// Obtém a transação atual.
        /// </summary>
        /// <returns>Transação atual.</returns>
        public IDbContextTransaction? GetCurrentTransaction() => currentTransaction;

        /// <summary>
        /// Indica se existe transação.
        /// </summary>
        public bool HasActiveTransaction => currentTransaction != null;

        /// <summary>
        /// Inicia uma nova instância da classe <see cref="BaseContext"/>.
        /// </summary>
        public BaseContext()
        {
            _ = (Database?.EnsureCreated());
        }

        /// <summary>
        /// Inicia uma nova instância da classe <see cref="BaseContext"/>.
        /// </summary>
        /// <param name="options">Opções do DbContext.</param>
        public BaseContext(DbContextOptions options) : base(options)
        {
            _ = (Database?.EnsureCreated());
        }

        /// <inheritdoc/>
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return (await SaveChangesAsync(cancellationToken).ConfigureAwait(true)) > 0;
        }

        /// <inheritdoc/>
        public async Task<IDbContextTransaction?> BeginTransactionAsync()
        {
            if (await Database.CanConnectAsync().ConfigureAwait(true))
            {
                return null;
            }

            if (currentTransaction != null)
            {
                return null;
            }

            _ = await Database.EnsureCreatedAsync().ConfigureAwait(true);

            currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(true);
            return currentTransaction;
        }

        /// <inheritdoc/>
        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            if (transaction != currentTransaction)
            {
                throw new InvalidOperationException($"Transação {transaction.TransactionId} não é a atual.");
            }

            try
            {
                var isObjectSavedAsync = await SaveEntitiesAsync().ConfigureAwait(true);

                if (isObjectSavedAsync)
                {
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (currentTransaction != null)
                {
                    currentTransaction.Dispose();
                    currentTransaction = null;
                }
            }
        }

        /// <inheritdoc/>
        public void RollbackTransaction()
        {
            try
            {
                currentTransaction?.Rollback();
            }
            finally
            {
                if (currentTransaction != null)
                {
                    currentTransaction.Dispose();
                    currentTransaction = null;
                }
            }
        }
    }
}