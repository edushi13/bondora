using MVCClient.Models;
using MVCClient.Services;

namespace MVCClient.Data
{
    public class ItemRepository
    {
        private IServerProxy _proxy;

        public ItemRepository(IServerProxy proxy)
        {
            _proxy = proxy;
        }

        public Item[] GetItems()
        {
            return _proxy.GetItems();
        }
    }
}
