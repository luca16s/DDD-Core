// <copyright file="BaseEntity.cs" company="Gian Luca da Silva Figueiredo">
// Copyright (c) Gian Luca da Silva Figueiredo. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace GianLuca.Domain.Core.Entity
{
    using System;
    using Flunt.Notifications;

    /// <summary>
    /// Entidade base.
    /// </summary>
    public class BaseEntity : Notifiable
    {
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="BaseEntity"/>.
        /// Construtor com geração automática de Identificador.
        /// </summary>
        public BaseEntity() => this.Id = Guid.NewGuid();

        /// <summary>
        /// Inicia uma nova instância da classe <see cref="BaseEntity"/>.
        /// Construtor com identificador passado via parametrô.
        /// </summary>
        /// <param name="idGuid">Identificador.</param>
        public BaseEntity(Guid idGuid)
        {
            if (idGuid != Guid.Empty)
            {
                this.Id = idGuid;
            }
        }

        /// <summary>
        /// Obtém identificador da entidade.
        /// </summary>
        public Guid Id { get; private set; }
    }
}
