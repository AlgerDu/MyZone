namespace MyZone.Server.Infrastructure.Interface
{
    /// <summary>
    /// 用作泛型约束
    /// </summary>
    public interface IEntity
    {

    }

    /// <summary>
    /// 带主键的泛型约束
    /// </summary>
    public interface IEntity<T> : IEntity
    {
        /// <summary>
        /// 实体主键
        /// </summary>
        T Key { get; }
    }
}