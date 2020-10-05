using MVCClient.Models;

namespace MVCClient.Services
{
    public interface IServerProxy
    {
        public Item[] GetItems();

        public Item GetItem(int id);

        public Invoice GenerateInvoiceAsync(Order order);
    }
}
