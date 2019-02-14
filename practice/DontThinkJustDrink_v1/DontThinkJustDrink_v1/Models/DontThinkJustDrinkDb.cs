using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DontThinkJustDrink_v1.Models
{
    public class DontThinkJustDrinkDb : DbContext
    {
        public DbSet<Drink> drinks { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}