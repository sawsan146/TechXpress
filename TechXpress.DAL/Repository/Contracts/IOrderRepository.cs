using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Repository.Contracts;

namespace TechXpress.DAL.Repository.Contracts
{
    public interface IOrderRepository : IRepository<Order, int>
    {

    }
}
