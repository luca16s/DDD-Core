// <copyright file="IBaseService.cs" company="Gian Luca da Silva Figueiredo">
// Copyright (c) Gian Luca da Silva Figueiredo. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace GianLuca.Domain.Core.Interfaces.Services
{
    using System;
    using System.Collections.Generic;
    using GianLuca.Domain.Core.Entity;

    public interface IBaseService<T> 
        where T : BaseEntity
    {
        T AddItem(T item);

        T GetItem(Guid id);

        IEnumerable<T> GetAllItems();

        T UpdateItem(Guid id, T item);

        void DeleteItem(T item);
    }
}
