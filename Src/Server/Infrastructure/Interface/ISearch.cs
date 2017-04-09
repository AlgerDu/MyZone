using System.Collections.Generic;
using System.Linq;

namespace MyZone.Server.Infrastructure.Interface
{
    /// <summary>
    /// 查询的过滤项
    /// </summary>
    public interface ISearchFilter
    {
        /// <summary>
        /// 字段名
        /// </summary>
        /// <returns></returns>
        string Field { get; }

        /// <summary>
        /// 字段值
        /// </summary>
        /// <returns></returns>
        string Value { get; }

        /// <summary>
        /// 是否排序
        /// </summary>
        /// <returns></returns>
        bool Order { get; }

        /// <summary>
        /// 操作方式
        /// </summary>
        /// <returns></returns>
        string Op { get; }
    }

    /// <summary>
    /// 查询条件
    /// </summary>
    public interface ISerachCondition
    {
        /// <summary>
        /// 每页数量，为 0 时代表不分页
        /// </summary>
        /// <returns></returns>
        long PageSize { get; }

        /// <summary>
        /// 页码，不分页时返回 1
        /// </summary>
        /// <returns></returns>
        long PageIndex { get; }

        IEnumerable<ISearchFilter> FilterItems { get; }
    }

    public interface ISearchResult<T> : IResult
        where T : class
    {
        /// <summary>
        /// 每页数量，为 0 时代表不分页
        /// </summary>
        /// <returns></returns>
        long PageSize { get; }

        /// <summary>
        /// 页码，不分页时返回 1
        /// </summary>
        /// <returns></returns>
        long PageIndex { get; }

        /// <summary>
        /// 总记录数
        /// </summary>
        /// <returns></returns>
        long RecoderCount { get; }

        /// <summary>
        /// 列表数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Data { get; }
    }
}