using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ContractsService.Data.Models;

namespace ContractsService.Data
{
    public interface IRepository<TSource>
    {
        List<TResult> Select<TResult>(Expression<Func<TSource, TResult>> selector);
        bool Update(TSource item);
        void Add(TSource item);
    }
}