using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models
{
    public static class Repository
    {
        private static List<OrderItem> orderItems = new List<OrderItem>();
        public static IEnumerable<OrderItem> OrderItems { get { return orderItems; } }
        public static void AddItem(OrderItem items)
        {
            orderItems.Add(items);
        }
        public static void Clear()
        {
            orderItems.Clear();
        }
    }
}