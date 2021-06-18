using Sogeti.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sogeti.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> ListAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<bool> SaveAsync(Customer Customer);
        Task<bool> UpdateAsync(int id, Customer Order);
        Task<bool> DeleteAsync(int id);
    }
}
