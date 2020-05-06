// <copyright file="IFactory.cs" company="Gian Luca da Silva Figueiredo">
// Copyright (c) Gian Luca da Silva Figueiredo. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace GianLuca.Domain.Core.Interfaces.Factory
{
    /// <summary>
    /// Interface para criação de fábricas.
    /// </summary>
    /// <typeparam name="T">Entidade.</typeparam>
    public interface IFactory<out T>
    {
        /// <summary>
        /// Instância novo objeto.
        /// </summary>
        /// <returns>Objeto instanciado.</returns>
        T Create();
    }
}
