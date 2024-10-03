﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AncientCities.Data.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);

        void Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}