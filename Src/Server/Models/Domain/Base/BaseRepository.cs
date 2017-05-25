using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Infrastructure.Results;
using MyZone.Server.Infrastructure.SearchBase;
using MyZone.Server.Models.DataBase;

namespace MyZone.Server.Models.Domain.Base
{
    /// <summary>
    /// respository 基类
    /// 定义一些基本操作，某些操作在一定条件下需要重载
    /// </summary>
    public abstract class BaseRepository<TEntity, KeyType> : IRepository<TEntity, KeyType>
        where TEntity : class, IAggregateRoot<KeyType>
    {
        protected DbContext _context;

        protected DbSet<TEntity> _dbSet;

        public virtual IQueryable<TEntity> Entities
        {
            get
            {
                return _dbSet;
            }
        }

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IResult Delete(KeyType key)
        {
            throw new NotImplementedException();
        }

        public virtual IResult Delete(TEntity entity)
        {
            var e = _dbSet.Remove(entity);
            return e.State == EntityState.Deleted ? Result.Success() : Result.Error();
        }

        public virtual IBathOpsResult Delete(IEnumerable<TEntity> entities)
        {
            var r = new BathOpsResult(entities.LongCount());
            var i = 0L;

            foreach (var entity in entities)
            {
                r.AddResultItem(i++, Delete(entity));
            }

            return r;
        }

        public virtual TEntity GetByKey(KeyType key)
        {
            return _dbSet.Find(key);
        }

        public virtual IResult Insert(TEntity entity)
        {
            var e = _dbSet.Add(entity);
            return e.State == EntityState.Added ? Result.Success() : Result.Error();
        }

        public virtual IBathOpsResult Insert(IEnumerable<TEntity> entities)
        {
            var r = new BathOpsResult(entities.LongCount());
            var i = 0L;

            foreach (var entity in entities)
            {
                r.AddResultItem(i++, Insert(entity));
            }

            return r;
        }

        public virtual IResult Update(TEntity entity)
        {
            var e = _dbSet.Update(entity);
            return e.State == EntityState.Modified ? Result.Success() : Result.Error();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public ISearchResult<TEntity> Search(ISerachCondition condition)
        {
            var result = new SearchResult<TEntity>(Entities.Count())
            {
                PageSize = condition.PageSize,
                PageIndex = condition.PageIndex,
                Code = 0
            };

            var records = Entities
                    .Skip((int)(condition.PageIndex * condition.PageSize - condition.PageSize))
                    .Take((int)condition.PageSize);

            result.SetRecords(records.ToList());

            return result;
        }
    }
}