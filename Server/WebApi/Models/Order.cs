using System.Collections.Generic;

namespace WebApi.Models
{
    public class Order
    {
        public List<OrderItem> Items { get; set; }

        public int CustomerId { get; set; }
    }
}
