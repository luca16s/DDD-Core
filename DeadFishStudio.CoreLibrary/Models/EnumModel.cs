﻿// -----------------------------------------------------------------------
// <copyright file="EnumModel.cs" company="DeadFish Studio">
// Copyright (c) DeadFish Studio. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace DeadFishStudio.CoreLibrary
{
    using System;

    /// <summary>
    /// Classe modelo para conversão de enumerador em lista.
    /// </summary>
    public class EnumModel
    {
        /// <summary>
        /// Valor do enum.
        /// </summary>
        public Enum? Value { get; set; }

        /// <summary>
        /// Descrição do enum.
        /// </summary>
        public string? Description { get; set; }
    }
}