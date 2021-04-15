// <copyright file="EnumDescriptionNotFoundException.cs" company="Îakaré Software'oka">
//     Copyright (c) Îakaré Software'oka. All rights reserved. Licensed under the MIT license. See
//     LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace CoreLibrary.Exceptions
{
    public class EnumDescriptionNotFoundException : Exception
    {
        private const string DefaultMessage = "Enum informado não contém descrição.";

        public EnumDescriptionNotFoundException()
            : base(DefaultMessage) { }

        public EnumDescriptionNotFoundException(string message)
            : base($"{DefaultMessage}\n - {message}") { }

        public EnumDescriptionNotFoundException(string message, Exception inner)
            : base($"{DefaultMessage}\n - {message}", inner) { }
    }
}