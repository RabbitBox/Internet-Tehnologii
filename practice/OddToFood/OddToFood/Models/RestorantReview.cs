using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddToFood.Models
{
    public class RestorantReview
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string body { get; set; }
        public int RestourantId { get; set; }
    }
}