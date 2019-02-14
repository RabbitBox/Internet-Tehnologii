using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DrinkAndGo1.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
       
        public int DrinkId { get; set; }
        public virtual Drink Drink { get; set; }

    }
}