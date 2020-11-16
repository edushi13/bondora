using WebApi.Models;

namespace WebApi.BL
{
    public interface IInvoiceGenerator
    {
        public Invoice GenerateInvoice(Order order);
    }
}
