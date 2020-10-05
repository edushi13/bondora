using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        [HttpPost]
        public ActionResult<Invoice> GenerateInvoice(Order order)
        {
            return CreatedAtAction("GenerateInvoice", new { id = 100 }, GetInvoice(order));
        }

        private Invoice GetInvoice(Order order)
        {
            int oneTimePrice = 100;
            int premiumPrice = 60;
            int regularPrice = 40;

            var invoice = new Invoice()
            {
                Title = $"Invoice for customer {order.CustomerId}",
                Items = new List<InvoiceItem>()
            };

            foreach (var orderItem in order.Items)
            {
                if (orderItem.Days < 1)
                    continue;
                int amount = 0;
                switch (orderItem.Type)
                {
                    case EquipmentType.Heavy:
                        amount = oneTimePrice + premiumPrice * orderItem.Days;
                        UpdateInvocie(invoice, orderItem, amount, 2);
                        break;
                    case EquipmentType.Regular:
                        
                        if (orderItem.Days > 2)
                        {
                            amount = oneTimePrice + 2 * premiumPrice + regularPrice * (orderItem.Days - 2);
                        }
                        else
                        {
                            amount = oneTimePrice + orderItem.Days * premiumPrice;
                        }
                        UpdateInvocie(invoice, orderItem, amount, 1);
                        break;
                    case EquipmentType.Specialized:
                        if (orderItem.Days > 3)
                        {
                            amount += 3 * premiumPrice + regularPrice * (orderItem.Days - 3);
                        }
                        else
                        {
                            amount += orderItem.Days * premiumPrice;
                        }
                        UpdateInvocie(invoice, orderItem, amount, 1);
                        break;
                }
            }

            return invoice;
        }

        private void UpdateInvocie(Invoice invoice, OrderItem item, int amount, int points)
        {
            invoice.Items.Add(new InvoiceItem() { ItemName = item.ItemName, Days = item.Days, Amount = amount });
            invoice.Points += points;
            invoice.Total += amount;
        }
    }
}
