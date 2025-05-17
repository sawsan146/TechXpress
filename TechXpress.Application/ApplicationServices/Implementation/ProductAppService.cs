using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs;
using TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Infrastructure;
using TechXpress.DAL.UnitOfWork;

namespace TechXpress.Application.ApplicationServices.Implementation
{
    public class ProductAppService: IProductAppService
    {
        private readonly IProductService _ProductService;
        private readonly IProductImageService _ProductImageService;
        private readonly IMapper _mapper;
        public ProductAppService(IProductService productService, IMapper mapper, IProductImageService productImageService)
        {
            _ProductService = productService;
            _mapper = mapper;
            _ProductImageService = productImageService;
        }
        public void AddProduct(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            _ProductService.Add(product); 
            
            if (productDto.UploadedImages != null && productDto.UploadedImages.Count > 0)
            {
                var productImages = new List<ProductImg>();

                foreach (var image in productDto.UploadedImages)
                {
                    productImages.Add(new ProductImg
                    {
                        ImageURL = image,
                        Product_ID = product.Product_ID 
                    });
                }

                _ProductImageService.AddRange(productImages);
            }
        }


        public void DeleteProduct(int id)
        {
            var product = _ProductService.GetById(id);
            if (product != null)
            {
                _ProductService.Delete(id);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public List<ProductDTO> GetAllProducts()
        {
            var products = _ProductService.GetAllProducts().ToList();
            var productDtos = _mapper.Map<List<ProductDTO>>(products);
            return productDtos;
        }

        public List<ProductDTO> GetAllProductsWithCategories()
        {
            var products = _ProductService.GetAllProducts().ToList();
            var productDtos = _mapper.Map<List<ProductDTO>>(products);
            return productDtos;
        }


        public List<ProductDTO> GetAllProductsWithCategoriesAndImages()
        {
            var products = _ProductService.GetAllProductsWithCategoriesAndImages().ToList();
            var productDtos = _mapper.Map<List<ProductDTO>>(products);
            if (productDtos!=null)
            {

                foreach (var productDto in productDtos)
                {
                    productDto.UploadedImages = productDto.UploadedImages ?? new List<string>();
                    foreach (var image in products.FirstOrDefault(p => p.Product_ID == productDto.ProductID)?.ProductImages)
                    {
                        productDto.UploadedImages.Add(image.ImageURL);
                    }
                }
            }
            return productDtos;
        }

        public ProductDTO GetProductById(int id)
        {
            var product = _ProductService.GetProductByIdWithImage(id);
            if (product != null)
            {
                var productDto = _mapper.Map<ProductDTO>(product);
                productDto.Image=product.ProductImages.FirstOrDefault()?.ImageURL;
                return productDto;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public void UpdateProduct(ProductDTO productDto)
        {
            var existingProduct = _ProductService.GetById(productDto.ProductID);
            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }

            _mapper.Map(productDto, existingProduct);
            _ProductService.Update(existingProduct);

            if (productDto.UploadedImages != null && productDto.UploadedImages.Count > 0)
            {
                if (existingProduct.ProductImages != null && existingProduct.ProductImages.Count > 0)
                {
                     _ProductImageService.DeleteByProductId(existingProduct.Product_ID);
                }

                var newImages = productDto.UploadedImages.Select(image => new ProductImg
                {
                    ImageURL = image,
                    Product_ID = existingProduct.Product_ID
                }).ToList();

                _ProductImageService.AddRange(newImages);
            }
        }

    }
}
