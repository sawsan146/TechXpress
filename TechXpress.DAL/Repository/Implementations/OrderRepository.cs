using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Infrastructure;
using TechXpress.DAL.Repository.Contracts;
using TechXpress.DAL.Repository.Implementations;

namespace TechXpress.DAL.Repository.Implementations
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

    }
}
