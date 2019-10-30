using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AirQualityDatabase.Utils.Repository.Base
{
    internal interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        void Add(in T entity);
        void AddRange(in IEnumerable<T> entities);
        void Remove(in T entity);
        void RemoveRange(in IEnumerable<T> entities);
    }
}