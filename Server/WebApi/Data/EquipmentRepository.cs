using WebApi.Models;

namespace WebApi.Data
{
    public class EquipmentRepository : IItemsRepository
    {
        private static Item[] _items = new Item[]
        {
            new Item()
            {
                ID = 1,
                Title = "Caterpillar bulldozer",
                Type = EquipmentType.Heavy
            },

            new Item()
            {
                ID = 2,
                Title = "Kamaz truck",
                Type = EquipmentType.Regular
            },

            new Item()
            {
                ID = 3,
                Title = "Komatsu crane",
                Type = EquipmentType.Heavy
            },

            new Item()
            {
                ID = 4,
                Title = "Volvo streamroller",
                Type = EquipmentType.Regular
            },

            new Item()
            {
                ID = 5,
                Title = "Bosch jackhammer",
                Type = EquipmentType.Specialized
            }
        };

        public Item[] GetItems()
        {
            return _items;
        }

        public Item GetItem(int id)
        {
            foreach (Item item in _items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
