using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;

namespace TechXpress.DAL.Repository.Contracts
{
    public interface IProductRepository :IRepository<Product,int>
    {
        public IEnumerable<Product> GetAllProductIncludingCategory();
        public IEnumerable<Product> GetAllProductIncludingCategoryAndImages();

        public Product GetProductByIdWithImage(int id);

        public IEnumerable<Product> GetAllProducts();

    }
}
