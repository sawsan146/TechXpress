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
            CreateMap<ProductDTO, Product>()
            .ForMember(dest => dest.ProductImages, opt => opt.MapFrom((src, dest) =>
               src.UploadedImages.Select(imgUrl => new ProductImg
               {
                   ImageURL = imgUrl,
                   Product_ID = dest.Product_ID
               }).ToList()));
            //.ForPath(dest => dest.Category.Name, opt => opt.MapFrom(src => src.CategoryName));
               
            

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.UploadedImages, opt => opt.MapFrom(src => src.ProductImages.Select(img => img.ImageURL).ToList()))
                .ForMember(dest => dest.ProductID, opt => opt.MapFrom(src => src.Product_ID))
                .ForMember(dest => dest.Category_ID, opt => opt.MapFrom(src => src.Category_ID))
                .ForPath(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
                
         





            // Category mapping
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Category_ID));

            CreateMap<CategoryDto, Category>()
                .ForMember(dest => dest.Category_ID, opt => opt.MapFrom(src => src.Id));
        }
    }

}
