using AutoMapper;
using System.Linq;
using MyZone.Server.Models.DataBase;
using MyZone.Server.Models.DTO.NovelCrawl;
using MyZone.Server.Models.DTO.BookStore;

namespace MyZone.Server.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Chapter, NovelCatalogChapterModel>();
            CreateMap<Volume, NovelCatalogVolumeModel>();
            CreateMap<Book, NovelCatalogModel>()
                .ForMember(d => d.Cs, op => op.MapFrom(s => s.Chapter.OrderBy(c => c.VolumeNo).ThenBy(c => c.VolumeIndex)))
                .ForMember(d => d.Vs, op => op.MapFrom(s => s.Volume.OrderBy(v => v.No)));
            CreateMap<Book, NovelStoreInfoModel>()
                .ForMember(d => d.ChapterCount, op => op.MapFrom(s => s.Chapter.Count()));
        }
    }
}