using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DontThinkJustDrink_v1.Models
{
    public class CategoryDrinkModel
    {
        public List<Drink> drinks{ get; set; }
        public Category category { get; set; }
    }
}