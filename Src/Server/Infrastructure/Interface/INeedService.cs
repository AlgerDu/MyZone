namespace MyZone.Server.Infrastructure.Interface
{
    /// <summary>
    /// 需要服务
    /// </summary>
    public interface INeedService
    {
        /// <summary>
        /// 注入服务 provider
        /// </summary>
        /// <param name="provider"></param>
        void InjecteService(IDServiceProvider provider);
    }
}