// -----------------------------------------------------------------------
// <copyright file="EnumExtension.cs" company="DeadFish Studio">
// Copyright (c) DeadFish Studio. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace DeadFishStudio.CoreLibrary.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
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
        /// <returns>Restorna a descrição do enumerador em formato texto.</returns>
        public static string Description(this Enum value)
        {
            var field = value
                      .GetType()
                      .GetField(value.ToString() ?? string.Empty);

            object[]? attributes = field?.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes?.Length == 0)
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

                return ti.ToTitleCase(ti.ToLower(value.ToString().Replace("_", " ", StringComparison.InvariantCultureIgnoreCase) ?? string.Empty));
            }

            return (attributes?.First() as DescriptionAttribute)?.Description ?? string.Empty;
        }

        /// <summary>
        /// Retorna uma lista com os valores contidos no enumerador.
        /// </summary>
        /// <param name="value">Enum a ser transformado em uma lista.</param>
        /// <returns>Lista dos itens do enumerador.</returns>
        public static IEnumerable<EnumModel> GetAllValuesAndDescriptions(this Enum value)
        {
            return value is not null
                ? Enum.GetValues(value.GetType()).Cast<Enum>().Select((e)
                => new EnumModel()
                {
                    Value = e,
                    Description = e.Description() ?? string.Empty
                }).ToList()
                : Enumerable.Empty<EnumModel>();
        }
    }
}