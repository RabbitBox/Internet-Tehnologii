using DrinkAndGo1.Data;
using DrinkAndGo1.Models;
using DrinkAndGo1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrinkAndGo1.Controllers
{
    public class ShoppingCartController : Controller
    {

         DrinkAndGoContext _db = new DrinkAndGoContext();
        

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCartItems = cart.GetShoppingCartItems(),
                ShoppingCartTotal = cart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        // GET: /Store/AddToCart/5
        public ActionResult AddToShoppingCart(int id)
        {
            // Retrieve the album from the database
            var selectedDrink = _db.Drinks.Single(p => p.DrinkId == id);


            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(selectedDrink);

            return RedirectToAction("Index");
        }

        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the drink to display confirmation
          /*  string drinkName = _db.ShoppingCartItems
                .Single(p => p.DrinkId == id).Drink.Name;*/

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                CartTotal = cart.GetShoppingCartTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        /*   public ActionResult RemoveFromShoppingCart(int id)
           {
               var selectedDrink = _db.Drinks.FirstOrDefault(p => p.DrinkId == id);
               if (selectedDrink != null)
               {
                   _shoppingCart.RemoveFromCart(selectedDrink);
               }
               return RedirectToAction("Index");
           }*/
        // GET: /ShoppingCart/CartSummary

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}