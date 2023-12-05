using AutoMapper;
using DTO;
using Entities;

namespace project

{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
      
            CreateMap<Order,OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Product, ProductDTO>().ForMember(dest => dest.CategoryName,
               opts => opts.MapFrom(src => src.Category.Name)).ReverseMap();
            CreateMap<Category, CtegoryDto>();
            
        }


    }
}

