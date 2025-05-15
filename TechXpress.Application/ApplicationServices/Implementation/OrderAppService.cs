using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs;
using TechXpress.BLL.Services.Contracts;
//using TechXpress.BLL.Services.Contracts.TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;

namespace TechXpress.Application.ApplicationServices.Implementation
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderAppService(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public OrderDto GetOrderById(int orderId)
        {
            var order = _orderService.GetById(orderId);
            if (order == null)
            {
                throw new System.Exception("Order not found");
            }
            return _mapper.Map<OrderDto>(order);
        }

        public List<OrderDto> GetAllOrders()
        {
            var orders = _orderService.GetAll();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public List<OrderDto> GetOrdersByUserId(int userId)
        {
            var orders = _orderService.GetOrdersByUserId(userId);
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public void AddOrder(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _orderService.Add(order);
        }

        public void UpdateOrder(OrderDto orderDto)
        {
            var existingOrder = _orderService.GetById(orderDto.OrderId);
            if (existingOrder == null)
            {
                throw new System.Exception("Order not found");
            }
            _mapper.Map(orderDto, existingOrder);
            _orderService.Update(existingOrder);
        }

        public void DeleteOrder(int orderId)
        {
            var order = _orderService.GetById(orderId);
            if (order == null)
            {
                throw new System.Exception("Order not found");
            }
            _orderService.Delete(orderId);
        }
    }
}