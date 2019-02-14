using DrinkAndGo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrinkAndGo1.ViewModels
{
    public class DrinkListViewModel
    {
        public IEnumerable<Drink> Drinks { get; set; }
        public string CurrentCategory { get; set; }
    }
}