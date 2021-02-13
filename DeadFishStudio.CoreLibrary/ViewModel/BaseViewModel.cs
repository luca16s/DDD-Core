// <copyright file="BaseViewModel.cs" company="Gian Luca da Silva Figueiredo">
// Copyright (c) Gian Luca da Silva Figueiredo. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DeadFishStudio.CoreLibrary
{
    using Microsoft.AspNetCore.Mvc;

    using System;

    /// <summary>
    /// ViewModelBase base.
    /// </summary>
    public class BaseViewModel
    {
        /// <summary>
        /// Obtém identificador da ViewModel.
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
    }
}