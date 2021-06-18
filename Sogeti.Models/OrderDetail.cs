using System;
using System.Collections.Generic;
using System.Text;

namespace Sogeti.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
