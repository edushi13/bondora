using WebApi.Models;

namespace WebApi.Data
{
    public interface IItemsRepository
    {
        public Item GetItem(int id);

        public Item[] GetItems();
    }
}
