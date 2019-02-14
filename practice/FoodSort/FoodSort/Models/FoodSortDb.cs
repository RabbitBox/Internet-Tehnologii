using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodSort.Models
{
    public class FoodSortDb : DbContext
    {
        public DbSet<Restourant> Restourants { get; set; }
        public DbSet<RestourantReviews> Reviews { get; set; }
    }
}