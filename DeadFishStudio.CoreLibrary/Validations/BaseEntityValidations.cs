// <copyright file="BaseEntityValidations.cs" company="DeadFish Studio">
// Copyright (c) DeadFish Studio. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DeadFishStudio.CoreLibrary.Validations
{
    using FluentValidation;

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
