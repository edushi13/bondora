using MVCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCClient.Formatters
{
    public class InvoiceFormatter : IInvoiceFormatter
    {
        public string FormatInvoice(Invoice invoice)
        {

            string result = $"{invoice?.Title}";
            result += "\n\n";

            result += "-----------------------------------------\n";
            result += "Item                            |  Amount\n";
            result += "-----------------------------------------\n";
            foreach (var item in invoice?.Items)
            {
                result += $"{item.ItemName}";
                var spaces = 32 - item.ItemName.Length;
                for (int i = 0; i < spaces; i++)
                {
                    result += " ";
                }
                result += "|  ";
                result += $"{item.Amount}\n";
            }
            result += "\n";
            result += $"Total\t\t\t\t   {invoice.Total}\n";
            result += $"Points\t\t\t\t   {invoice.Points}\n";
            return result;
        }
    }
}
