using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sogeti.Services;
using Sogeti.Models;
using Sogeti.Repository;

namespace Sogeti.Tests.OrderService
{
    [TestFixture]
    public class OrderServiceTests
    {
        private Mock<IOrderRepository> mockRepository;

        [SetUp]
        public void Setup()
        {
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

            mockRepository = new Mock<IOrderRepository>();
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int i) => ordersList.Where(x => x.Id == i).Single());
            mockRepository.Setup(x => x.InsertAsync(It.IsAny<Order>())).ReturnsAsync(true);
            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(ordersList);
            mockRepository.Setup(x => x.DeleteAsync(2)).ReturnsAsync(true);
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<Order>())).ReturnsAsync(true);
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<Order>())).ReturnsAsync(true);

        }
        [Test]
        public void GetOrderById()
        {
            var service = new Services.OrderService(mockRepository.Object);
            var orderRespose = service.GetOrderByIdAsync(1).Result;
            Assert.AreEqual(orderRespose.Id, 1);
            Assert.AreEqual(orderRespose.PaymentId, 1);
            Assert.AreEqual(orderRespose.Status, OrderStatus.Received);
        }

        [Test]
        public void CreateOrder()
        {
            var orderDetail = new OrderDetail()
            {
                OrderId = 3,
                ProductId = 1,
                Status = OrderStatus.Received
            };

            var order1 = new Order()
            {
                Id = 3,
                CustomerId = 1,
                DateCreated = DateTime.Now.Date,
                DateUpdated = DateTime.Now.Date,
                Details = orderDetail,
                PaymentId = 1,
                Status = OrderStatus.Received,
                Total = 100
            };

            var service = new Services.OrderService(mockRepository.Object);
            var result = service.SaveAsync(order1).Result;

            Assert.AreEqual(result, true);

        }

        [Test]
        public void CancelOrder()
        {
            var orderDetail = new OrderDetail()
            {
                OrderId = 3,
                ProductId = 1,
                Status = OrderStatus.Received
            };

            var order1 = new Order()
            {
                Id = 3,
                CustomerId = 1,
                DateCreated = DateTime.Now.Date,
                DateUpdated = DateTime.Now.Date,
                Details = orderDetail,
                PaymentId = 1,
                Status = OrderStatus.Received,
                Total = 100
            };

            var service = new Services.OrderService(mockRepository.Object);
            var orderRespose = service.GetOrderByIdAsync(1).Result;

            orderRespose.Status = OrderStatus.Canceled;
            orderRespose.DateUpdated = DateTime.Now.Date;

            var result = service.UpdateAsync(orderRespose.Id, orderRespose).Result;
            Assert.AreEqual(result, true);
        }

    }
}
