using Sogeti.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sogeti.Services
{
    public interface IOrderService
    {
        Task<List<Order>> ListAsync();
        Task<List<Order>> GetOrdersAsync(IEnumerable<int> id);
        Task<Order> GetOrderByIdAsync(int id);
        Task<bool> SaveAsync(Order Order);
        Task<bool> UpdateAsync(int id, Order Order);
        Task<bool> DeleteAsync(int id);
    }
}
