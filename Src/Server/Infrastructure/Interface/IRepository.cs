using System.Collections.Generic;
using System.Linq;

namespace MyZone.Server.Infrastructure.Interface
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    public interface IRepository<TEntity, KeyType> where TEntity : IAggregateRoot<KeyType>
    {
        /// <summary>
        /// 仓储中的实体列表
        /// </summary>
        IQueryable<TEntity> Entities { get; }

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IResult Insert(TEntity entity);

        IBathOpsResult Insert(IEnumerable<TEntity> entities);

        IResult Delete(KeyType key);

        IResult Delete(TEntity entity);

        IBathOpsResult Delete(IEnumerable<TEntity> entities);

        IResult Update(TEntity entity);

        TEntity GetByKey(KeyType key);
    }
}