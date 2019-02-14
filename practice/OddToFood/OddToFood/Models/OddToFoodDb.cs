using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OddToFood.Models
{
    public class OddToFoodDb : DbContext
    {
        public DbSet<Restourant> Restourants { get; set; }
        public DbSet<RestorantReview> Reviews { get; set; }
    }
}