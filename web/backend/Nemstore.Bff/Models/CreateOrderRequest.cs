using System.Collections.Generic;

namespace Nemstore.Bff.Models
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
