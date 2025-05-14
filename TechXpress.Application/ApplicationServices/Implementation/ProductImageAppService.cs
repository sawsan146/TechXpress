using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;

namespace TechXpress.Application.ApplicationServices.Implementation
{
    public class ProductImageAppService : IProductImageAppService
    {
        private readonly IProductImageService _productImageService;
        public ProductImageAppService(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }


        public void AddProductImage(string img)
        {

        }

        public void Deleteimg(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductImg> GetAllImgs()
        {
            throw new NotImplementedException();
        }

        public ProductImg GetImgById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(string img)
        {
            throw new NotImplementedException();
        }
    }
}
