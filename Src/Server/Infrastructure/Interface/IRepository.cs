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
        /// 通用简单查询接口
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ISearchResult<TEntity> Search(ISerachCondition condition);

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IResult Insert(TEntity entity);

        /// <summary>
        /// 批量插入实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        IBathOpsResult Insert(IEnumerable<TEntity> entities);

        /// <summary>
        /// 通过主键删除实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IResult Delete(KeyType key);

        /// <summary>
        /// 通过实体对象删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IResult Delete(TEntity entity);

        /// <summary>
        /// 通过实体对象批量删除实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        IBathOpsResult Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// 更细实体对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IResult Update(TEntity entity);

        /// <summary>
        /// 通过主键获取一个实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity GetByKey(KeyType key);

        /// <summary>
        /// 提交修改
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}