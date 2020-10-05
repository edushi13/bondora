using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCClient.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public EquipmentType Type { get; set; }

        public int Days { get; set; }
    }

    public enum EquipmentType
    {
        Heavy = 1,
        Regular = 2,
        Specialized = 3
    }
}
