using System;

namespace Sogeti.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public decimal Total { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public OrderStatus Status { get; set; }

        public OrderDetail Details { get; set; }

        public int PaymentId { get; set; }
    }
}
