using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Invoice
    {
        public string Title { get; set; }

        public List<InvoiceItem> Items { get; set; }

        public int Total { get; set; }

        public int Points { get; set; }
    }
}
