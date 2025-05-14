using System.Collections.Generic;
using System.Threading.Tasks;
using TechXpress.Application.DTOs;

namespace TechXpress.Application.ApplicationServices.Contracts
{
    using global::TechXpress.DAL.Entities;
    using System.Collections.Generic;

    namespace TechXpress.BLL.Services.Contracts
    {
        public interface IOrderService
        {
            Order? GetOrderById(int orderId);
            List<Order> GetAllOrders();
            void AddOrder(Order order);
            void UpdateOrder(Order order);
            void DeleteOrder(int orderId);
        }
    }


}
