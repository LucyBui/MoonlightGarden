using MoonlightGarden.Platform;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MoonlightGarden.Platform
{
    public abstract class RepositoryBase<T> where T : InputData
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<T> dbSet;
        public RepositoryBase(DbContext ctx)
        {
            dbContext = ctx;
            dbSet = dbContext.Set<T>();
        }

        public T FindOne(string Id)
        {
            return dbSet.Find(Id);
        }

        #region Query
        protected IQueryable<T> FilterBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }
        protected Dictionary<string, TResult> FilterBy<TResult>(Expression<Func<T, bool>> predicate) where TResult : OutputData
        {
            return FilterBy(predicate).ToDictionary(item => item.Id, item => item.Clone<TResult>());
        }
        protected Dictionary<string, TResult> FilterByRowKey<TResult>(string rowKey) where TResult : OutputData
        {
            return FilterBy<TResult>(item => item.RowKey == rowKey);
        }
        #endregion

        #region CRUD
        public bool Add(List<T> entities)
        {
            foreach (T entity in entities)
            {
                dbSet.Add(entity);
            }
            return dbContext.SaveChanges() > 0;
        }
        public bool Save(T entity)
        {
            T origin = FindOne(entity.Id);
            if (origin == null)
            {
                dbSet.Add(entity);                
            }
            else
            {
                dbContext.Entry(origin).CurrentValues.SetValues(entity);
            }
            return dbContext.SaveChanges() > 0;
        }
        public bool Delete(string id)
        {
            dbSet.Remove(FindOne(id));
            return dbContext.SaveChanges() > 0;
        }
        public bool DropByKey(string key)
        {            
            dbSet.RemoveRange(FilterBy(item => item.RowKey == key));
            return dbContext.SaveChanges() > 0;
        }
        #endregion
    }
}