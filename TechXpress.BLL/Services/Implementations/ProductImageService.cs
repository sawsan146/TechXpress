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
    public class ProductImageService : Service<ProductImg,int>, IProductImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<Service<ProductImg, int>> _logger;
        public ProductImageService(IRepository<ProductImg,int> repository, IUnitOfWork unitOfWork, ILogger<Service<ProductImg,int>> logger) : base(repository, unitOfWork, logger)
        {
            _unitOfWork = unitOfWork;
            _logger= logger;
        }

        public bool AddRange(List<ProductImg> productImages)
        {
            if (productImages == null || productImages.Count == 0)
                throw new ArgumentNullException(nameof(productImages));
            try
            {
                foreach (var image in productImages)
                {
                   _unitOfWork.ProductImages.Add(image);
                }
                //_unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding product images.");
                return false;
            }
        }

        public void DeleteByProductId(int productId)
        {
            try
            {
                var productImages = _unitOfWork.ProductImages.GetAll().Where(x => x.Product_ID == productId).ToList();
                if (productImages != null && productImages.Count > 0)
                {
                    foreach (var image in productImages)
                    {
                        _unitOfWork.ProductImages.Delete(image.Image_ID);
                    }
                }
                //_unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product images by product ID.");
            }
        }
    }

}
