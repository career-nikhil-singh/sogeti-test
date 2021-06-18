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
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet("{id}", Name = "GetOrders")]
        public async Task<List<Order>> Get()
        {
            return await _orderService.ListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<Order> Get(int id)
        {
            return await _orderService.GetOrderByIdAsync(id);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<bool> Post(int orderId, Order order)
        {
            return await _orderService.UpdateAsync(orderId, order);
        }

        // PUT: api/Orders/5
        [HttpGet("{id}", Name = "UpdateOrder")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpGet("{id}", Name = "CancelOrder")]
        public void Delete(int id)
        {
        }
    }
}
