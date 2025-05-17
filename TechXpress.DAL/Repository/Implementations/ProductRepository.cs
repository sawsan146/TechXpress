using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Infrastructure;
using TechXpress.DAL.Repository.Contracts;

namespace TechXpress.DAL.Repository.Implementations
{
    public class ProductRepository : Repository<Product,int>, IProductRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProductIncludingCategory()
        {
            try
            {
                return _dbContext.Products.Include(p => p.Category).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving products with categories.", ex);
            }
        }

        public IEnumerable<Product> GetAllProductIncludingCategoryAndImages()
        {
            try
            {
                return _dbContext.Products.Include(p => p.Category).Include(p => p.ProductImages).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving products with categories and images.", ex);
            }
        }

        public  IEnumerable<Product> GetAllProducts()
        {

            try
            {
                return _dbContext.Products.Include(p => p.Category).Include(p => p.ProductImages).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all products.", ex);
            }

        }

        public Product GetProductByIdWithImage(int id)
        {
            try
            {
                return _dbContext.Products.Include(p => p.ProductImages).FirstOrDefault(p => p.Product_ID == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the product with ID {id}.", ex);
            }
        }
    }
}
