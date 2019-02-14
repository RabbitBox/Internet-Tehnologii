using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTJD.Models
{
    public class CategoryDrinkModel
    {
        public List<Drink> drinks { get; set; }
        public string currentCategory { get; set; }
    }
}