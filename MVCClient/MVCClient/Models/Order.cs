using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCClient.Models
{
    public class Order
    {
        public List<OrderItem> Items { get; set; }

        public int CustomerId { get; set; }
    }
}
