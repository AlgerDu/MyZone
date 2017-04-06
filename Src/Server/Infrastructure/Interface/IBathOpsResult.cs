using System.Collections;
using System.Collections.Generic;

namespace MyZone.Server.Infrastructure.Interface
{
    /// <summary>
    /// 通用数据返回接口
    /// </summary>
    public interface IBathOpsResultItem
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// item 在批量操作中顺序
        /// </summary>
        int Index { get; }

        /// <summary>
        /// 返回消息
        /// </summary>
        string Message { get; }
    }

    /// <summary>
    /// 批量操作结果
    /// </summary>
    public interface IBathOpsResult : IResult
    {
        /// <summary>
        /// 操作的总数
        /// </summary>
        int OpsCount { get; }

        /// <summary>
        /// 操作结果
        /// </summary>
        IEnumerable<IBathOpsResultItem> Items { get; }
    }

    /// <summary>
    /// 批量操作结果项（泛型）
    /// </summary>
    public interface IBathOpsResultItem<T>
    {
        /// <summary>
        /// 返回码 0 代表成功
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// item 在批量操作中顺序
        /// </summary>
        int Index { get; }

        /// <summary>
        /// 返回消息
        /// </summary>
        string Message { get; }

        /// <summary>
        /// 需要返回的数据
        /// </summary>
        T Data { get; }
    }

    /// <summary>
    /// 批量操作结果（泛型）
    /// </summary>
    public interface IBathOpsResult<T> : IResult
        where T : class
    {
        /// <summary>
        /// 操作的总数
        /// </summary>
        int OpsCount { get; }

        /// <summary>
        /// 操作结果
        /// </summary>
        IEnumerable<IBathOpsResultItem<T>> Items { get; }
    }
}