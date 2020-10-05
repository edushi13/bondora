using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCClient.Models
{
    public class OrderItem
    {
        public int ItemId { get; set; }

        //public string Title { get; set; }

        public string ItemName { get; set; }
        public EquipmentType Type { get; set; }

        public int Days { get; set; }
    }
}
