using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Infrastructure;
using TechXpress.Logic.Repository.Contracts;

namespace TechXpress.Logic.Repository.Implementations
{
    public class ProductRepository : Repository<Product,int>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
