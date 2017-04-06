using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Infrastructure.Results;

namespace MyZone.Server.Models.Domain.Base
{
    public abstract class BaseRepository<TEntity, KeyType> : IRepository<TEntity, KeyType>
        where TEntity : class, IAggregateRoot<KeyType>
    {
        protected DbSet<TEntity> _dbSet;

        public virtual IQueryable<TEntity> Entities
        {
            get
            {
                return _dbSet;
            }
        }

        IQueryable<TEntity> IRepository<TEntity, KeyType>.Entities => throw new NotImplementedException();

        public BaseRepository(DbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public virtual IResult Delete(KeyType key)
        {
            throw new NotImplementedException();
        }

        public virtual IResult Delete(TEntity entity)
        {
            return _dbSet.Remove(entity) != null ? Result.Success() : Result.Error();
        }

        public virtual IBathOpsResult Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetByKey(KeyType key)
        {
            throw new NotImplementedException();
        }

        public virtual IResult Insert(TEntity entity)
        {
            return _dbSet.Add(entity) != null ? Result.Success() : Result.Error();
        }

        public virtual IBathOpsResult Insert(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual IResult Update(TEntity entity)
        {
            return _dbSet.Update(entity) != null ? Result.Success() : Result.Error();
        }

        IResult IRepository<TEntity, KeyType>.Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        IBathOpsResult IRepository<TEntity, KeyType>.Insert(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        IResult IRepository<TEntity, KeyType>.Delete(KeyType key)
        {
            throw new NotImplementedException();
        }

        IResult IRepository<TEntity, KeyType>.Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        IBathOpsResult IRepository<TEntity, KeyType>.Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        IResult IRepository<TEntity, KeyType>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity, KeyType>.GetByKey(KeyType key)
        {
            throw new NotImplementedException();
        }

        int IRepository<TEntity, KeyType>.SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}