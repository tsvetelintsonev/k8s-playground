using System.Collections.Generic;

namespace Nemstore.Orders.Api.Models
{
    public class CreateOrderRequest
    {
        public IEnumerable<CreateOrderRequestLine> Lines { get; set; }
    }

    public class CreateOrderRequestLine
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
