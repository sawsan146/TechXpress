using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.BLL.Services.Contracts.TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Repository.Contracts;

namespace TechXpress.BLL.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order, int> _orderRepository;

        public OrderService(IRepository<Order, int> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public bool Add(Order entity)
        {
            try
            {
                _orderRepository.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Order entity)
        {
            try
            {
                _orderRepository.Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _orderRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}