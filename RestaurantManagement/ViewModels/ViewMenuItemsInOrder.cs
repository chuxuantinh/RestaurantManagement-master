using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagement.ViewModels
{
    public class ViewMenuItemsInOrder
    {
        public IEnumerable<Menu> MenuItems { get; set; }


        //public Repository Repository { get; set; }
    }
}