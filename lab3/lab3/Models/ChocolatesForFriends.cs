using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab3.Models
{
    public class ChocolatesForFriends
    {
        public FriendModel friend { get; set; }

        public List<Chocolate> chocolates { get; set; }

        public int selectedChocolateId { get; set; }

        public int f_id { get; set; }
    }
}