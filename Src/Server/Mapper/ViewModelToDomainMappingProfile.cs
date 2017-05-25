using AutoMapper;
using MyZone.Server.Models.DataBase;
using MyZone.Server.Models.Domain.Books;
using MyZone.Server.Models.DTO.NovelCrawl;

namespace MyZone.Server.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<NovelAddModel, Book>();
            CreateMap<VolumeUploadModel, Volume>();
            CreateMap<ChapterUploadModel, Chapter>();
        }
    }
}