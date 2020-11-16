using WebApi.Models;

namespace WebApi.BL.Calculators
{
    public interface ICalculator
    {
        InvoiceItem GetInvoiceItem(OrderItem orderItem);

        int Points { get; }
    }
}
