using WebApi.Models;

namespace WebApi.BL.Calculators
{
    public class SpecializedCalculator : ICalculator
    {
        public int Points => 1;

        public InvoiceItem GetInvoiceItem(OrderItem orderItem)
        {
            int amount;
            if (orderItem.Days > 3)
            {
                amount = 3 * (int)Fees.Premium + (int)Fees.Regular * (orderItem.Days - 3);
            }
            else
            {
                amount = orderItem.Days * (int)Fees.Premium;
            }

            return new InvoiceItem() { ItemName = orderItem.ItemName, Days = orderItem.Days, Amount = amount };
        }
    }
}
