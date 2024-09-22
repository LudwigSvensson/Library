using AutoMapper;
using Library.Models;
using Library.Models.DTO_s;

namespace Library.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, BookCreateDTO>().ReverseMap();
            CreateMap<Book, BookUpdateDTO>().ReverseMap();
        }
    }
}
