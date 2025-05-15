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
            CreateMap<ProductDashBoardViewModel, ProductDTO>()
                .ForMember(dest => dest.UploadedImages, opt => opt.MapFrom(src =>
                    src.UploadedImages.Select(f => f.FileName).ToList()));
           

            CreateMap<ProductDTO, ProductDashBoardViewModel>()
            .ForMember(dest => dest.ImageNamesForDisplay, opt => opt.MapFrom(src => src.UploadedImages))
            .ForMember(dest => dest.UploadedImages, opt => opt.Ignore()); 


            CreateMap<ProductDTO, ProductDetailsViewModel>();
            CreateMap<ProductDetailsViewModel, ProductDTO>();
        }
    }
}
