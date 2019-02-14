using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab3.Models
{
    public class FriendModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Range(0, 200, ErrorMessage ="Id must be a number between 0 and 200")]
        public int Friend_id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string place { get; set; }

        [Required]
        public string imgURL { get; set; }

        public List<Chocolate> chocolates { get; set; }
    }
}