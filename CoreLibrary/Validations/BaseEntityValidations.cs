// <copyright file="BaseEntityValidations.cs" company="Îakaré Software'oka">
//     Copyright (c) Îakaré Software'oka. All rights reserved. Licensed under the MIT license. See
//     LICENSE file in the project root for full license information.
// </copyright>

namespace CoreLibrary.Validations
{
    using CoreLibrary.Models;

    using FluentValidation;

    /// <summary>
    /// Validação da entidade base.
    /// </summary>
    public class BaseEntityValidations :
        AbstractValidator<BaseEntity>
    {
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="BaseEntityValidations" />.
        /// </summary>
        public BaseEntityValidations()
        {
            _ = RuleFor(baseEntity => baseEntity.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}