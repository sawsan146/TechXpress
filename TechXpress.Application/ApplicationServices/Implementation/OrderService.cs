using System.Collections.Generic;
using System.Linq;
using TechXpress.Application.ApplicationServices.Contracts.TechXpress.BLL.Services.Contracts;
using TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;
using TechXpress.Logic.Repository.Contracts;

namespace TechXpress.BLL.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order, int> _orderRepository;

        public OrderService(IRepository<Order, int> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order? GetOrderById(int orderId)
        {
            return _orderRepository.GetById(orderId);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
        }

        public void DeleteOrder(int orderId)
        {
            _orderRepository.Delete(orderId);
        }
    }
}
