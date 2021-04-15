// <copyright file="BaseEntityValidations.cs" company="Îakaré Software'oka">
//     Copyright (c) Îakaré Software'oka. All rights reserved. Licensed under the MIT license. See
//     LICENSE file in the project root for full license information.
// </copyright>

using CoreLibrary.Models;

using FluentValidation;

namespace CoreLibrary.Validations
{
    public class BaseEntityValidations : AbstractValidator<BaseEntity>
    {
        public BaseEntityValidations()
        {
            RuleFor(baseEntity => baseEntity.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}