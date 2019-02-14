using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTJD.Models
{
    public class Drink
    {
        public int DrinkId { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string ImageTumbnailUrl { get; set; }

        public bool IsPreferreDrink { get; set; }

        public int InStock { get; set; }

        public int CategoryId { get; set; } 

        public virtual Category Category { get; set; }
    }
}