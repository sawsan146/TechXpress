using AutoMapper;
using TechXpress.Application.DTOs;
using TechXpress.Application.DTOs.TechXpress.Web.DTO;
using TechXpress.DAL.Entities;

namespace TechXpress.Web.Mapping
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            // Product mapping
            CreateMap<Product, ProductDTO>();

            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.Product_ID, opt => opt.Ignore())
                .ForMember(dest => dest.Category_ID, opt => opt.MapFrom(src => src.Category_ID))
                .ForMember(dest => dest.AddTime, opt => opt.MapFrom(src =>
                    src.AddTime == default ? DateTime.Now : src.AddTime))
                .ForMember(dest => dest.ProductImages, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDetails, opt => opt.Ignore())
                .ForMember(dest => dest.CartItems, opt => opt.Ignore())
                .ForMember(dest => dest.Reviews, opt => opt.Ignore());

            // Category mapping
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Category_ID));

            CreateMap<CategoryDto, Category>()
                .ForMember(dest => dest.Category_ID, opt => opt.MapFrom(src => src.Id));
        }
    }

}
