// <copyright file="IFactory.cs" company="Gian Luca da Silva Figueiredo">
// Copyright (c) Gian Luca da Silva Figueiredo. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DeadFishStudio.CoreLibrary
{
    /// <summary>
    /// Interface para criação de fábricas.
    /// </summary>
    /// <typeparam name="T">Tipo que define entidade a ser instanciada.</typeparam>
    /// <typeparam name="TReturn">Entidade Instanciada.</typeparam>
    public interface IFactory<T, out TReturn>
    {
        TReturn Create(T type);
    }
}