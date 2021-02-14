// <copyright file="BaseViewModel.cs" company="DeadFish Studio">
// Copyright (c) DeadFish Studio. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DeadFishStudio.CoreLibrary
{
    using System;

    /// <summary>
    /// ViewModelBase base.
    /// </summary>
    public class BaseViewModel
    {
        /// <summary>
        /// Obtém identificador da ViewModel.
        /// </summary>
        public Guid Id { get; set; }
    }
}