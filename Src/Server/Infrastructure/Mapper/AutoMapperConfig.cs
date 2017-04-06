using AutoMapper;

namespace MyZone.Server.Infrastructure.Mapper
{
    /// <summary>
    /// AutoMapper 配置项
    /// </summary>
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
            });
        }
    }
}