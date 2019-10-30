using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AirQualityDatabase.Utils.Repository.Base
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        #region Properties
        protected DbContext Context { get; }
        #endregion

        #region Constructors
        public Repository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region IRepository
        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }
        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().SingleOrDefault(predicate);
        }
        public void Add(in T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public void AddRange(in IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }
        public void Remove(in T entity)
        {
            Context.Set<T>().Remove(entity);
        }
        public void RemoveRange(in IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }
        #endregion
    }
}