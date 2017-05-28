using AutoMapper;
using System.Linq;
using MyZone.Server.Models.DataBase;

namespace MyZone.Server.Models.DTO.BookManagement
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, NovelListModel>();

            CreateMap<Book, NovelCatalogModel>()
                .ForMember(d => d.Cs, op => op.MapFrom(s => s.Chapter.OrderBy(c => c.VolumeNo).ThenBy(c => c.VolumeIndex)))
                .ForMember(d => d.Vs, op => op.MapFrom(s => s.Volume.OrderBy(v => v.No)));

            CreateMap<Chapter, NovelCatalogChapterModel>()
                .ForMember(d => d.Crawled, op => op.MapFrom(s => !s.NeedCrawl));
            CreateMap<Volume, NovelCatalogVolumeModel>();
        }
    }
}