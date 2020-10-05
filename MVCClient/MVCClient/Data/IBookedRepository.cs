using MVCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCClient.Data
{
    public interface IBookedRepository
    {
        public OrderItem[] GetBooked();

        public void AddToOrder(int id, string title, EquipmentType type);

        public void RemoveFromOrder(int id);

        public void Update(int id, int days);

        public OrderItem GetOrderItem(int id);
    }
}
