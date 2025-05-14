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
    public class CategoryService : Service<Category, string>, ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IRepository<Category, string> repository, IUnitOfWork unitOfWork, ILogger<Service<Category, string>> logger)
            : base(repository, unitOfWork, logger)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
