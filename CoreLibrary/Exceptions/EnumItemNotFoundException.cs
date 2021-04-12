// <copyright file="EnumItemNotFoundException.cs" company="Îakaré Software'oka">
// Copyright (c) Îakaré Software'oka. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CoreLibrary.Exceptions
{
    using System;

    public class EnumItemNotFoundException : Exception
    {
        private const string DefaultMessage = "Item não encontrado no enumerador.";

        public EnumItemNotFoundException()
            : base(DefaultMessage) { }

        public EnumItemNotFoundException(string message)
            : base($"{DefaultMessage}\n - {message}") { }

        public EnumItemNotFoundException(string message, Exception inner)
            : base($"{DefaultMessage}\n - {message}", inner) { }
    }
}