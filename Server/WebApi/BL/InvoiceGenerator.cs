using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.BL
{
    public class InvoiceGenerator : IInvoiceGenerator
    {
        private CalculatorFactory _factory;

        public InvoiceGenerator(CalculatorFactory factory)
        {
            _factory = factory;
        }

        private void AddItem(Invoice invoice, OrderItem orderItem)
        {
            var calc = _factory.GetCalculator(orderItem.Type);
            InvoiceItem invoiceItem = calc.GetInvoiceItem(orderItem);
            invoice.Items.Add(invoiceItem);
            invoice.Points += calc.Points;
            invoice.Total += invoiceItem.Amount;
        }

        public Invoice GenerateInvoice(Order order)
        {
            var invoice = new Invoice()
            {
                Title = $"Invoice for customer {order?.CustomerId}",
                Items = new List<InvoiceItem>()
            };

            foreach (var orderItem in order.Items)
            {
                if (orderItem.Days < 1)
                    continue;

                AddItem(invoice, orderItem);
            }

            return invoice;
        }
    }
}
