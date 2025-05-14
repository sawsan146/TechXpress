using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Application.DTOs;
using TechXpress.DAL.Entities;

namespace TechXpress.Application.ApplicationServices.Contract
{
    public interface IProductImageAppService
    {
        public void AddProductImage(string img);
        public void UpdateProduct(string img);
        public void Deleteimg(int id);
        public ProductImg GetImgById(int id);
        public List<ProductImg> GetAllImgs();
    }
}
