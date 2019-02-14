using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodSort.Models
{
    public class RestourantReviews
    {
        public int Id { get; set; }
        public int Rating { get; set; }
     
        public string Text { get; set; }
        public int RestourantId { get; set; }
    }
}