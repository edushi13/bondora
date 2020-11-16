using WebApi.Models;

namespace WebApi.BL.Calculators
{
    public class RegularCalculator : ICalculator
    {
        public int Points => 1;

        public InvoiceItem GetInvoiceItem(OrderItem orderItem)
        {
            int amount;
            if (orderItem.Days > 2)
            {
                amount = (int)Fees.OneTime + 2 * (int)Fees.Premium + (int)Fees.Regular * (orderItem.Days - 2);
            }
            else
            {
                amount = (int)Fees.OneTime + orderItem.Days * (int)Fees.Premium;
            }

            return new InvoiceItem() { ItemName = orderItem.ItemName, Days = orderItem.Days, Amount = amount };
        }
    }
}
