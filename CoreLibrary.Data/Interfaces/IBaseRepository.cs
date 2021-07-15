// <copyright file="IBaseRepository.cs" company="Îakaré Software'oka">
//     Copyright (c) Îakaré Software'oka. All rights reserved. Licensed under the MIT license. See
//     LICENSE file in the project root for full license information.
// </copyright>

namespace CoreLibrary.Data.Interfaces
{
    using System;
    using System.Collections.Generic;

    using CoreLibrary.Models;

    /// <summary>Interface síncrona para salvamento no banco de dados.</summary>
    /// <typeparam name="T">Entidade que será salva.</typeparam>
    public interface IBaseRepository<T>
        where T : BaseEntity<T>
    {
        /// <summary>Adiciona nova entidade no banco de dados.</summary>
        /// <param name="item">Entidade a ser salva.</param>
        /// <returns>Entidade salva.</returns>
        T AddItem(T item);

        /// <summary>Deleta uma entidade no banco de dados.</summary>
        /// <param name="item">Entidade a ser deletada.</param>
        void DeleteItem(T item);

        /// <summary>Retorna todas as entidades do banco de dados.</summary>
        /// <returns>Todas as entidades.</returns>
        IEnumerable<T> GetAllItems();

        /// <summary>Retorna uma entidade com base em um identificador.</summary>
        /// <param name="id">Identificador da entidade.</param>
        /// <returns>Entidade encontrada.</returns>
        T GetItem(Guid id);

        /// <summary>Atualiza uma entidade com base em um identificador.</summary>
        /// <param name="id">Identificador da entidade.</param>
        /// <param name="item">Entidade a ser atualizada.</param>
        /// <returns>Entidade atualizado.</returns>
        T UpdateItem(Guid id, T item);
    }
}