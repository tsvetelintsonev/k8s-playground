using System;
using System.Collections.Generic;

namespace Nemstore.Orders.Api.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public IList<OrderLine> Lines { get; set; }
        public OrderStatus Status { get; set; }
    }

    public class OrderLine
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public enum OrderStatus 
    {
        Created, AwaitingStockApproval, Completed
    }
}
