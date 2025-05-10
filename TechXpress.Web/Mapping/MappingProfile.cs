using AutoMapper;
using TechXpress.Application.DTOs;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDashBoardViewModel, ProductDTO>();

           CreateMap<ProductDTO, ProductDashBoardViewModel>();

        }

    }
}
