using System.Collections.Generic;
using TechXpress.DAL.Entities;

namespace TechXpress.BLL.Services.Contracts
{
    public interface IOrderService : IService<Order, int>
    {
        Order GetById(int id);
        List<Order> GetAll();
        List<Order> GetOrdersByUserId(int userId);
        bool Add(Order entity);
        bool Update(Order entity);
        bool Delete(int id);
    }
}