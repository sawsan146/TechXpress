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

            // Cart mapping
            CreateMap<CartItems, CartItemDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductImage, opt => opt.MapFrom(src => src.Product.ProductImages.First()));

            CreateMap<ShoppingCart, ShoppingCartDTO>()
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Total_Price));

            // Order mapping
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Order_ID))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.CreationTime))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.CustomerName, opt => opt.Ignore());

            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.Order_ID, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.User_ID, opt => opt.Ignore());


            //ContactMessage
            CreateMap<ContactMassegeDTO, ContactMessage>();

            //User mapping
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
                
        }
    }
}