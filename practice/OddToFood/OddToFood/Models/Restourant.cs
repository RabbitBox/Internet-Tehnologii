using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddToFood.Models
{
    public class Restourant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<RestorantReview> Reviews { get; set; }
    }
}