using Moq;
using NUnit.Framework;
using Sogeti.Models;
using Sogeti.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sogeti.TestProject
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private Mock<IOrderRepository> mockOrderRepository;
        private Mock<ICustomerRepository> mockCustomerRepository;

        [SetUp]
        public void Setup()
        {
            var customer1 = new Customer()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "User",
                MiddleName = "Sogeti",
                OrdersList = new List<int> { 1, 2, 3 }
            };

            mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(customer1);
                       
            var orderDetail = new OrderDetail()
            {
                OrderId = 1,
                ProductId = 1,
                Status = OrderStatus.Received
            };

            var order1 = new Order()
            {
                Id = 1,
                CustomerId = 1,
                DateCreated = DateTime.Now.Date,
                DateUpdated = DateTime.Now.Date,
                Details = orderDetail,
                PaymentId = 1,
                Status = OrderStatus.Received,
                Total = 100
            };

            var orderDetail2 = new OrderDetail()
            {
                OrderId = 2,
                ProductId = 1,
                Status = OrderStatus.Received
            };

            var order2 = new Order()
            {
                Id = 2,
                CustomerId = 1,
                DateCreated = DateTime.Now.Date,
                DateUpdated = DateTime.Now.Date,
                Details = orderDetail2,
                PaymentId = 1,
                Status = OrderStatus.Received,
                Total = 100
            };
            var ordersList = new List<Order> { order1, order2 };

            mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderRepository.Setup(x => x.GetMultipleByIdAsync(It.IsAny<List<int>>())).ReturnsAsync(ordersList);
        }

        [Test]
        public void GetCustomerOrders()
        {
            var customerService = new Services.CustomerService(mockCustomerRepository.Object);
            var customerOrdersList = customerService.GetCustomerByIdAsync(1).Result.OrdersList;

            var orderService = new Services.OrderService(mockOrderRepository.Object);
            var ordersList = orderService.GetOrdersAsync(customerOrdersList).Result.Count;

            Assert.AreEqual(ordersList, 2);

        }
    }
}
