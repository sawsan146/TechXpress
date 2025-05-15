using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Application.DTOs;

namespace TechXpress.Application.ApplicationServices.Contract
{
    public interface IProductAppService
    {
        public void AddProduct(ProductDTO productDto);
        public void UpdateProduct(ProductDTO productDto);
        public void DeleteProduct(int id);
        public ProductDTO GetProductById(int id);

        public List<ProductDTO> GetAllProducts();

        public List<ProductDTO> GetAllProductsWithCategories();

        public List<ProductDTO> GetAllProductsWithCategoriesAndImages();

    }
}
