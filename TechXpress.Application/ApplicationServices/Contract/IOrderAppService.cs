using System.Collections.Generic;
using TechXpress.Application.DTOs;

namespace TechXpress.Application.ApplicationServices.Contract
{
    public interface IOrderAppService
    {
        OrderDto GetOrderById(int orderId);
        List<OrderDto> GetAllOrders();
        List<OrderDto> GetOrdersByUserId(int userId);
        void AddOrder(OrderDto orderDto);
        void UpdateOrder(OrderDto orderDto);
        void DeleteOrder(int orderId);
    }
}