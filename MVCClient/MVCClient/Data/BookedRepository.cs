using MVCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCClient.Data
{
    public class BookedRepository : IBookedRepository
    {
        private Order _order;

        private Order Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new Order();
                    _order.Items = new List<OrderItem>();
                }
                return _order;
            }
        }

        public void AddToOrder(int id, string title, EquipmentType type)
        {
            var found = Order.Items.Find(a => a.ItemId == id);
            if (found != null)
            {
                found.Days = 0;
            }
            else
            {
                _order.Items.Add(new OrderItem { ItemName = title, ItemId = id, Type = type, Days = 0 });
            }
        }

        public void RemoveFromOrder(int id)
        {
            var found = Order.Items.Find(a => a.ItemId == id);
            if (found != null)
            {
                Order.Items.Remove(found);
            }
        }

        public void Update(int id, int days)
        {
            var found = Order.Items.Find(a => a.ItemId == id);
            if (found != null)
            {
                found.Days = days;
            }
        }

        public Order GetOrder()
        {
            return Order;
        }

        public OrderItem GetOrderItem(int id)
        {
            var found = Order.Items.Find(a => a.ItemId == id);
            return found;
        }

        public OrderItem[] GetBooked()
        {
            return Order.Items.ToArray();
        }

    }
}
