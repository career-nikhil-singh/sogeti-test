using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sogeti.Models;
using Sogeti.Repository;

namespace Sogeti.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository CustomerRepository)
        {
            _customerRepository = CustomerRepository;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _customerRepository.DeleteAsync(id);
            return result;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var result = await _customerRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<List<Customer>> ListAsync()
        {
            var result = await _customerRepository.GetAllAsync();
            return result;
        }

        public async Task<bool> SaveAsync(Customer Customer)
        {
            return await _customerRepository.InsertAsync(Customer);
        }

        public async Task<bool> UpdateAsync(int id, Customer Customer)
        {
            var result = await _customerRepository.UpdateAsync(id, Customer);
            return result;
        }
    }
}
