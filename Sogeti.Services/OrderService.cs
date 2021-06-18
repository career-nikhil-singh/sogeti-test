using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sogeti.Models;
using Sogeti.Repository;

namespace Sogeti.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _orderRepository.DeleteAsync(id);
            return result;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var result = await _orderRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<List<Order>> GetOrdersAsync(IEnumerable<int> id)
        {
            var result = await _orderRepository.GetMultipleByIdAsync(id);
            return result;
        }

        public async Task<List<Order>> ListAsync()
        {
            var result= await _orderRepository.GetAllAsync();
            return result;
        }

        public async Task<bool> SaveAsync(Order Order)
        {
            return await _orderRepository.InsertAsync(Order);
        }

        public async Task<bool> UpdateAsync(int id, Order Order)
        {
            var result = await _orderRepository.UpdateAsync(id, Order);
            return result;
        }
    }
}
