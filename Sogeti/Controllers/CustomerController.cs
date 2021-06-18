using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sogeti.Models;
using Sogeti.Services;

namespace Sogeti.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public CustomerController(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
        }

        [HttpGet("get/{id}")]
        public async Task<Customer> Get(int id)
        {
            return await _customerService.GetCustomerByIdAsync(id);
        }

        [HttpGet(Name = "GetAllCustomers")]
        public async Task<List<Customer>> Get()
        {
            return await _customerService.ListAsync();
        }

        [HttpGet("{id}", Name = "GetCustomerOrders")]
        public async Task<List<Order>> GetOrdersAsync(int id)
        {
            var ordersIdList = _customerService.GetCustomerByIdAsync(id).Result.OrdersList.ToList();
            var orders = await _orderService.GetOrdersAsync(ordersIdList);
            return orders;
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
