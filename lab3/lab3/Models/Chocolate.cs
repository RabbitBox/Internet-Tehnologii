using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab3.Models
{
    public class Chocolate
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public string manufacturer { get; set; }

        public bool nutriApproved { get; set; }
    }
}