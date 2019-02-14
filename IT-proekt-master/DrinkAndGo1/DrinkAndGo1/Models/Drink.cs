using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace DrinkAndGo1.Models
{
    public class Drink
    {
        [BindNever]
        public int DrinkId { get; set; }

        [Required(ErrorMessage = "Please enter the name of drink")]
        [Display(Name = "Name of a drink")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter short description")]
        [Display(Name = "Short description")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Please enter long description")]
        [Display(Name = "Long description")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Please enter the price")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price, price can't have more than 2 decimal places")]
        [Range(0.1, 100)]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Please enter a image")]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please enter a image")]
        [Display(Name = "Image thumbnail Url")]
        public string ImageThumbnailUrl { get; set; }


        [Display(Name = "Is preferred drink")]
        public bool IsPreferredDrink { get; set; }

        [Required(ErrorMessage = "Please enter a stock")]
        [Display(Name = "In stock")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int InStock { get; set; }

        [Required(ErrorMessage = "Please enter a category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}