using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DTJD.Models
{
    public class DTJD_Db : DbContext
    {
        public DbSet<Drink> drinks { get; set; }
        public DbSet<Category> categories { get; set; }

       
    }
}