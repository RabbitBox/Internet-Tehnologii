using DrinkAndGo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrinkAndGo1.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}