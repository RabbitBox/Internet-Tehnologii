using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrinkAndGo1.Models
{
    public class AddToRoleModel
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public List<string> roles { get; set; }
    }
}