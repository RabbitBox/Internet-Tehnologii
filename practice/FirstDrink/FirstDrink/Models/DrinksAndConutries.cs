using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstDrink.Models
{
    public class DrinksAndConutries
    {
        public Drink drink { get; set; }
        public List<Countries> countriesDrinks { get; set; }
    }
}