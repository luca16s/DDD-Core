// <copyright file="BaseEntity.cs" company="Îakaré Software'oka">
//     Copyright (c) Îakaré Software'oka. All rights reserved. Licensed under the MIT license. See
//     LICENSE file in the project root for full license information.
// </copyright>

namespace CoreLibrary.Models
{
    /// <summary>Entidade base.</summary>
    public class BaseEntity<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity" /> class. Inicia uma nova
        /// instância da classe <see cref="BaseEntity" />. Construtor com identificador passado via parametrô.
        /// </summary>
        /// <param name="id">Identificador.</param>
        public BaseEntity(T id)
        {
            Id = id;
        }

        /// <summary>Obtém identificador da entidade.</summary>
        public T Id { get; private set; }
    }
}