using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.BLL.Services.Contracts;
using TechXpress.Logic.UnitOfWork;
using TechXpress.Application.DTOs;
using AutoMapper;
using TechXpress.DAL.Entities;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.DAL.Infrastructure;

namespace TechXpress.Application.ApplicationServices.Implementation
{
    public class ProductAppService: IProductAppService
    {
        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;
        public ProductAppService(IProductService productService, IMapper mapper)
        {
            _ProductService = productService;
            _mapper = mapper;
        }

        public void AddProduct(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _ProductService.Add(product);           

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
            var products = _ProductService.GetAll().ToList();
            var productDtos = _mapper.Map<List<ProductDTO>>(products);
            return productDtos;
        }

        public ProductDTO GetProductById(int id)
        {
            var product = _ProductService.GetById(id);
            if (product != null)
            {
                var productDto = _mapper.Map<ProductDTO>(product);
                return productDto;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public void UpdateProduct(ProductDTO productDto)
        {
          
           var product= _mapper.Map<Product>(productDto);
            var p = _ProductService.GetById(product.Product_ID);
            if (product != null)
            {
              
                _ProductService.Update(product);
            }
            else
            {
                throw new Exception("Product not found");
            }

        }
    }
}
