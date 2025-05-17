using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;
namespace TechXpress.BLL.Services.Contracts
{
    public interface IProductService : IService<Product, int>
    {
        
        public IEnumerable<Product> GetAllProductsWithCategories();
        public IEnumerable<Product> GetAllProductsWithCategoriesAndImages();

        public Product GetProductByIdWithImage(int id);
        public IEnumerable<Product> GetAllProducts();
    }

}
