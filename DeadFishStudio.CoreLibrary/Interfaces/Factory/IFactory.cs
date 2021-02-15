﻿// <copyright file="IFactory.cs" company="DeadFish Studio">
// Copyright (c) DeadFish Studio. All rights reserved.
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
        /// <summary>
        /// Instancia um tipo concreto.
        /// </summary>
        /// <param name="type">Tipo a ser instanciado.</param>
        /// <returns>Tipo concreto.</returns>
        TReturn Create(T type);
    }
}