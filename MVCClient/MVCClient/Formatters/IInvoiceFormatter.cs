using MVCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCClient.Formatters
{
    public interface IInvoiceFormatter
    {
        string FormatInvoice(Invoice invoice);
    }
}
