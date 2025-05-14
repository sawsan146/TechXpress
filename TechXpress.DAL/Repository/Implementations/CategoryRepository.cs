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
    using TechXpress.DAL.Infrastructure;
    using TechXpress.DAL.Entities;
    using TechXpress.Logic.Repository.Implementations;

    public class CategoryRepository : Repository<Category, string>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

    }


}