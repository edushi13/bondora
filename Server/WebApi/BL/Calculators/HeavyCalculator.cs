using WebApi.Models;

namespace WebApi.BL.Calculators
{
    public class HeavyCalculator : ICalculator
    {
        public int Points => 2;

        public InvoiceItem GetInvoiceItem(OrderItem orderItem)
        {
            int amount = (int)Fees.OneTime + (int)Fees.Premium * orderItem.Days;
            return new InvoiceItem() { ItemName = orderItem.ItemName, Days = orderItem.Days, Amount = amount };
        }
    }
}
