using Moq;
using NUnit.Framework;
using Sogeti.Repository;
using Sogeti.Services;
using Sogeti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sogeti.Models;

namespace Sogeti.Tests.OrderService
{
    public class Tests
    {
        private Mock<ICustomerService> customerServiceMock;
        private Mock<IOrderService> orderServiceMock;
        private Mock<OrderRepository> mockRepository;

        [SetUp]
        public void Setup()
        {
            var orderDetail = new OrderDetail() {
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

            var Order2 = new Order();
            var ordersList = new List<Order> { order1, Order2 };

            mockRepository = new Mock<OrderRepository>();

            mockRepository.Setup(r => r.Get(order1.Id)).Returns(order1);
            mockRepository.Setup(r => r.GetAll()).Returns(ordersList.AsQueryable);

            var service = new Services.OrderService(mockRepository.Object);
        }
        [Test]
        public void Test1()
        {
            var order1 = new Order();
            var service = new Services.OrderService(mockRepository.Object);

            var orderRespose = service.GetOrderByIdAsync(order1.Id);
            Assert.AreEqual(order1, orderRespose);
        }

    }
}
