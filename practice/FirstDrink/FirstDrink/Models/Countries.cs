using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstDrink.Models
{
    public class Countries
    {
        [Required]
        public string name { get; set; }
        [Required]
        public int population { get; set; }
        [Required]
        public string religion { get; set; }
    }
}