using AutoMapper;
using MyZone.Server.Models.DataBase;

namespace MyZone.Server.Models.DTO.BookManagement
{
    public class BookManagementMappingProfile : Profile
    {
        public BookManagementMappingProfile()
        {
            CreateMap<Book, NovelListModel>();
        }
    }
}