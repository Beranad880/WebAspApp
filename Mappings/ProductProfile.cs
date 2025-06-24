using AutoMapper;
using WebAspApp.DTOs;
using WebAspApp.Models;

namespace WebAspApp.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<ProductCreateDTO, Product>();
        }
    }
}