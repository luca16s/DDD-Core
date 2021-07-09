// <copyright file="IUnitOfWork.cs" company="Îakaré Software'oka">
//     Copyright (c) Îakaré Software'oka. All rights reserved. Licensed under the MIT license. See
//     LICENSE file in the project root for full license information.
// </copyright>

namespace CoreLibrary.Data.Interfaces
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore.Storage;

    /// <summary>Classe para servir de interface no salvamento do banco de dados.</summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>Inicia transação com o banco de dados.</summary>
        /// <returns>Retorna a transação.</returns>
        IDbContextTransaction? BeginTransaction();

        /// <summary>Inicia transação com o banco de dados.</summary>
        /// <returns>Retorna a transação.</returns>
        Task<IDbContextTransaction?> BeginTransactionAsync();

        /// <summary>Comita a transação do banco.</summary>
        /// <param name="transaction">Transação aberta.</param>
        void CommitTransaction(IDbContextTransaction transaction);

        /// <summary>Comita a transação do banco.</summary>
        /// <param name="transaction">Transação aberta.</param>
        /// <returns>Retorna a task.</returns>
        Task CommitTransactionAsync(IDbContextTransaction transaction);

        /// <summary>Reverte alterações.</summary>
        void RollbackTransaction();

        /// <summary>Salva as modificações no banco.</summary>
        /// <param name="cancellationToken">Cancela o processo de salvamento.</param>
        /// <returns>Retorna o status da operação.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>Salva as modificações no banco.</summary>
        /// <returns>Retorna o status da operação.</returns>
        bool SaveEntities();

        /// <summary>Salva a entidade modificada.</summary>
        /// <param name="cancellationToken">Cancela o processo de salvamento da entidade.</param>
        /// <returns>Retorna o sucesso da operação.</returns>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}