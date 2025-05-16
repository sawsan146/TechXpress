using AutoMapper;
using TechXpress.Application.DTOs;
using TechXpress.DAL.Entities;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //product mapping
            CreateMap<ProductDashBoardViewModel, ProductDTO>()
                .ForMember(dest => dest.UploadedImages, opt => opt.MapFrom(src =>
                    src.UploadedImages.Select(f => f.FileName).ToList()));


            CreateMap<ProductDTO, ProductDashBoardViewModel>()
            .ForMember(dest => dest.ImageNamesForDisplay, opt => opt.MapFrom(src => src.UploadedImages))
            .ForMember(dest => dest.UploadedImages, opt => opt.Ignore());


            CreateMap<ProductDTO, ProductDetailsViewModel>();
            CreateMap<ProductDetailsViewModel, ProductDTO>();




            //Cart Mapping
            CreateMap<CartItemDTO, CartitemsViewModel>()
          .ForMember(dest => dest.Product, opt => opt.MapFrom(src => new ProductViewModel
          {
              Id = src.Product_ID,
              Name = src.ProductName,
              Price = src.Price,
              Image = src.ProductImage
          }));

            CreateMap<ShoppingCartDTO, ShoppingCartViewModel>()
                .ForMember(dest => dest.OrderTotal, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.ShoppingCartList, opt => opt.MapFrom(src => src.CartItems));

            //Contact Message Mapping
            CreateMap<ContactMessageViewModel, ContactMassegeDTO>();

        }
    }
}

