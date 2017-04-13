using AutoMapper;
using MyZone.Server.Models.DataBase;

namespace MyZone.Server.Models.DTO.Novel
{
    /// <summary>
    /// NovelController 使用的 mapping 的配置
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Chapter, LastChapterModel>();

            CreateMap<Chapter, ChapterModel>();
            CreateMap<Volume, VolumeModel>();
        }
    }
}