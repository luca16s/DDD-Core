// <copyright file="BaseEntity.cs" company="Îakaré Software'oka">
// Copyright (c) Îakaré Software'oka. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CoreLibrary
{
    using System;

    /// <summary>
    /// Entidade base.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class.
        /// Inicia uma nova instância da classe <see cref="BaseEntity"/>.
        /// Construtor com geração automática de Identificador.
        /// </summary>
        public BaseEntity() => Id = Guid.NewGuid();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class.
        /// Inicia uma nova instância da classe <see cref="BaseEntity"/>.
        /// Construtor com identificador passado via parametrô.
        /// </summary>
        /// <param name="idGuid">Identificador.</param>
        public BaseEntity(Guid idGuid)
        {
            if (idGuid != Guid.Empty)
            {
                Id = idGuid;
            }
        }

        /// <summary>
        /// Obtém identificador da entidade.
        /// </summary>
        public Guid Id { get; private set; }
    }
}