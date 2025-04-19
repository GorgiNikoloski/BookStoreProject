using BookStore.Domain.Domain;
using BookStore.Repository.Interface;
using BookStore.Service.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll().ToList();
        }

        public Order GetDetailsForOrder(BaseEntity model)
        {
            return _orderRepository.Get(model.Id);
        }
    }
}
