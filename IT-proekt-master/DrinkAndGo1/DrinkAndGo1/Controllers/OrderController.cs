using DrinkAndGo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrinkAndGo1.Controllers
{
    public class OrderController : Controller
    {
       
        ShoppingCart _shoppingCart=new ShoppingCart();


        public OrderController() { }


        [Authorize]
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Checkout(Order order)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var items = cart.GetShoppingCartItems();
            cart.ShoppingCartItems = items;
            if (cart.ShoppingCartItems == null)
            {
                return RedirectToAction("CheckoutNotComplete");
            }

            if (ModelState.IsValid)
            {
                cart.CreateOrder(order);
                cart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public ActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order! :) ";
            return View();
        }

        public ActionResult CheckoutNotComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Your card is empty, add some drinks first";
            return View();
        }
    }
}