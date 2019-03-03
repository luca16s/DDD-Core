// <copyright file="IBaseRepositoryAsync.cs" company="Gian Luca da Silva Figueiredo">
// Copyright (c) Gian Luca da Silva Figueiredo. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace GianLuca.Domain.Core.Interfaces.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GianLuca.Domain.Core.Entity;

    public interface IBaseRepositoryAsync<T> where T : BaseEntity
    {
        Task<T> AddItemAsync(T item);
        Task<T> GetItemAsync(Guid id);
        Task<IEnumerable<T>> GetAllItemsAsync();
        T UpdateItem(Guid id, T item);
        void DeleteItem(T item);
    }
}
