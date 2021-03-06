namespace MyZone.Server.Infrastructure.Interface
{
    /// <summary>
    /// 聚合跟接口
    /// </summary>
    public interface IAggregateRoot : IEntity
    {

    }

    /// <summary>
    /// 聚合跟接口（泛型）
    /// </summary>
    public interface IAggregateRoot<T> : IAggregateRoot
    {

    }
}