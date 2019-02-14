using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace lab3.Models
{
    public class FriendsAndChocholatesDB : DbContext
    {
        public DbSet<FriendModel> Friends { get; set; }

        public DbSet<Chocolate> Chocolates { get; set; }

    }
}