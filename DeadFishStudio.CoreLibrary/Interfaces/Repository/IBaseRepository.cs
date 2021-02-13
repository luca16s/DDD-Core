// <copyright file="IBaseRepository.cs" company="Gian Luca da Silva Figueiredo">
// Copyright (c) Gian Luca da Silva Figueiredo. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DeadFishStudio.CoreLibrary
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface síncrona para salvamento no banco de dados.
    /// </summary>
    /// <typeparam name="T">Entidade que será salva.</typeparam>
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        /// <summary>
        /// Adiciona nova entidade no banco de dados.
        /// </summary>
        /// <param name="item">Entidade a ser salva.</param>
        /// <returns>Entidade salva.</returns>
        T AddItem(T item);

        /// <summary>
        /// Retorna uma entidade com base em um identificador.
        /// </summary>
        /// <param name="id">Identificador da entidade.</param>
        /// <returns>Entidade encontrada.</returns>
        T GetItem(Guid id);

        /// <summary>
        /// Retorna todas as entidades do banco de dados.
        /// </summary>
        /// <returns>Todas as entidades.</returns>
        IEnumerable<T> GetAllItems();

        /// <summary>
        /// Atualiza uma entidade com base em um identificador.
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