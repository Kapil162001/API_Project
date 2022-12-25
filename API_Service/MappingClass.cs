using API_Repository.Models;
using API_Repository.Models.DTO;
using AutoMapper;

namespace API_Service
{
    public class MappingClass : Profile
    {
        public MappingClass()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();
        }

    }
}
