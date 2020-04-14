using System;
using System.Collections.Generic;
using System.Linq;

namespace Nemstore.Orders.Api.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public IList<OrderLine> Lines { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Total => Lines.Sum(line => line.TotalPrice);
    }

    public class OrderLine
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }

    public enum OrderStatus 
    {
        Created, AwaitingStockApproval, Completed
    }
}
