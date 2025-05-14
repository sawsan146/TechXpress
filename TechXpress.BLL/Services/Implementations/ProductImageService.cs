using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Repository.Contracts;
//using TechXpress.DAL.UnitOfWork;
using TechXpress.Logic.Repository.Contracts;
using TechXpress.Logic.UnitOfWork;

namespace TechXpress.BLL.Services.Implementations
{
    public class ProductImageService : Service<ProductImg>, IProductImageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductImageService(IRepository<ProductImg> repository, IUnitOfWork unitOfWork, ILogger<Service<ProductImg>> logger) : base(repository, unitOfWork, logger)
        {
            _unitOfWork = unitOfWork;

        }
    }

}
