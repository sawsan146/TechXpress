using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;
using TechXpress.Logic.Repository.Contracts;
using TechXpress.Logic.UnitOfWork;

namespace TechXpress.BLL.Services.Implementations
{
    public class ProductService : Service<Product>, IProductService
    {
         private readonly IUnitOfWork _unitOfWork;
        public ProductService(IRepository<Product> repository, IUnitOfWork unitOfWork, ILogger<Service<Product>> logger)
            : base(repository, unitOfWork, logger)
        {
            _unitOfWork = unitOfWork;
        }

   
    }

}
