using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCClient.Models
{
    public class InvoiceItem
    {
        public string ItemName { get; set; }

        public int Days { get; set; }

        public int Amount { get; set; }
    }
}
