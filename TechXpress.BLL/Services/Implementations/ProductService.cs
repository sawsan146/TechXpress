using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Repository.Contracts;
using TechXpress.DAL.UnitOfWork;

namespace TechXpress.BLL.Services.Implementations
{
    public class ProductService : Service<Product, int>, IProductService
    {
         private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, ILogger<Service<Product, int>> logger)
            : base(productRepository, unitOfWork, logger)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                var products = _unitOfWork.Products.GetAllProducts().ToList();
                return products;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while retrieving all products.", ex);
            }
        }

        public IEnumerable<Product> GetAllProductsWithCategories()
        {
            try
            {
                var products = _unitOfWork.Products.GetAllProductIncludingCategory().ToList();
                return products;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while retrieving products with categories.", ex);
            }
        }

        public IEnumerable<Product> GetAllProductsWithCategoriesAndImages()
        {
            try
            {
                var products = _unitOfWork.Products.GetAllProductIncludingCategoryAndImages().ToList();
                return products;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while retrieving products with categories and images.", ex);
            }
        }
    }

}
