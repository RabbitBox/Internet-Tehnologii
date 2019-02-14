using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstDrink.Models
{
    public class Drink
    {
        public int  id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string img { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be a positive number > 0")]
        public float rating { get; set; }

        [Required]
        public string ingredients { get; set; }

        public bool isAlcoholic { get; set; }
    }
}