// <copyright file="IBaseRepositoryAsync.cs" company="DeadFish Studio">
// Copyright (c) DeadFish Studio. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DeadFishStudio.CoreLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface assíncrona para salvamento no banco de dados.
    /// </summary>
    /// <typeparam name="T">Entidade que será salva.</typeparam>
    public interface IBaseRepositoryAsync<T>
        where T : BaseEntity
    {
        /// <summary>
        /// Adiciona nova entidade no banco de dados de forma assíncrona.
        /// </summary>
        /// <param name="item">Entidade a ser salva.</param>
        /// <returns>Entidade salva.</returns>
        Task<T> AddItemAsync(T item);

        /// <summary>
        /// Retorna uma entidade com base em um identificador de forma assíncrona.
        /// </summary>
        /// <param name="id">Identificador da entidade.</param>
        /// <returns>Entidade encontrada.</returns>
        Task<T> GetItemAsync(Guid id);

        /// <summary>
        /// Retorna todas as entidades do banco de dados de forma assíncrona.
        /// </summary>
        /// <returns>Todas as entidades.</returns>
        Task<IEnumerable<T>> GetAllItemsAsync();

        /// <summary>
        /// Atualiza uma entidade com base em um identificador passado.
        /// </summary>
        /// <param name="id">Identificador da entidade.</param>
        /// <param name="item">Entidade a ser atualizada.</param>
        /// <returns>Entidade atualizado.</returns>
        T UpdateItem(Guid id, T item);

        /// <summary>
        /// Deleta uma entidade no banco de dados.
        /// </summary>
        /// <param name="item">Entidade a ser deletada.</param>
        void DeleteItem(T item);
    }
}