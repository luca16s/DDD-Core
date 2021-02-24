// -----------------------------------------------------------------------
// <copyright file="EnumExtension.cs" company="DeadFish Studio">
// Copyright (c) DeadFish Studio. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace DeadFishStudio.CoreLibrary.Extensions
{
    using DeadFishStudio.CoreLibrary.Exceptions;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// Classe de extensão para operações com enumeradores.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Busca a descrição do Enumerador passado.
        /// </summary>
        /// <param name="value">Enum a ter a descrição retornada.</param>
        /// <returns>Retorna a descrição do enumerador em formato texto.</returns>
        /// <exception cref="EnumDescriptionNotFoundException">Descrição não encontrada.</exception>
        public static string Description(this Enum value)
        {
            object[]? attributes = value
                ?.GetType()
                ?.GetField(value.ToString())
                ?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                ?? Array.Empty<Array>();

            if (attributes != null
                && attributes.Length > 0
                && attributes?.First() is DescriptionAttribute description)
                return description.Description;

            throw new EnumDescriptionNotFoundException();
        }

        /// <summary>
        /// Retorna uma lista com os valores contidos no enumerador.
        /// </summary>
        /// <param name="value">Enum a ser transformado em uma lista.</param>
        /// <returns>Lista dos itens do enumerador.</returns>
        public static IEnumerable<EnumModel> GetAllValuesAndDescriptions(this Enum value)
        {
            return Enum.GetValues(value.GetType()).Cast<Enum>().Select((e)
                => new EnumModel()
                {
                    Value = e,
                    Description = e.Description()
                }).ToList();
        }
    }
}