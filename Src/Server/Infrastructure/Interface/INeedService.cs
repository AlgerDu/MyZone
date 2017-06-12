namespace MyZone.Server.Infrastructure.Interface
{
    /// <summary>
    /// 需要服务
    /// </summary>
    public interface INeedService
    {
        /// <summary>
        /// 注入服务 collection
        /// </summary>
        /// <param name="collection"></param>
        void InjecteService(IDServiceCollection collection);
    }
}