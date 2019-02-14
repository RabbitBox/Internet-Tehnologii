using DrinkAndGo1.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;

namespace DrinkAndGo1.Models
{
    public class ShoppingCart
    {
        DrinkAndGoContext _db = new DrinkAndGoContext();
        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart()
        {
            
        }

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }



        public void AddToCart(Drink drink)
        {
            var shoppingCartItem = _db.ShoppingCartItems.SingleOrDefault(
                         s => s.Drink.DrinkId == drink.DrinkId && s.ShoppingCartId == ShoppingCartId);

            // Create a new cart item if no cart item exists
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem();
                shoppingCartItem.Amount = 1;
                shoppingCartItem.DrinkId = drink.DrinkId;
                shoppingCartItem.ShoppingCartId = ShoppingCartId;
               
                _db.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                shoppingCartItem.Amount++;
            }
            // Save changes
            _db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var shoppingCartItem =
                    _db.ShoppingCartItems.FirstOrDefault(
                        s => s.Drink.DrinkId == id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _db.ShoppingCartItems.Remove(shoppingCartItem);
                }

                _db.SaveChanges();
            }

            return localAmount;

        }

        public void EmptyCart()
        {
            var cartItems = _db.ShoppingCartItems.Where(
                cart => cart.ShoppingCartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                _db.ShoppingCartItems.Remove(cartItem);
            }
            // Save changes
            _db.SaveChanges();
        }


        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _db.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Drink)
                           .ToList());

            // return _db.ShoppingCartItems.Where(
            //    cart => cart.ShoppingCartId== ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            var items = _db.ShoppingCartItems.Where (
                cartItems => cartItems.ShoppingCartId == ShoppingCartId);
            int count = items.ToList().Count;
                         
            // Return 0 if all entries are null
            return count;
        }

       
        public decimal GetShoppingCartTotal()
        {
            decimal? total = _db.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Drink.Price * c.Amount).DefaultIfEmpty(0).Sum();
            return total ?? decimal.Zero;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = _db.ShoppingCartItems.Where(
                c => c.ShoppingCartId == ShoppingCartId);

            foreach (ShoppingCartItem item in shoppingCart)
            {
                item.ShoppingCartId = userName;
            }
            _db.SaveChanges();
        }



        public void CreateOrder(Order order)
        {
            decimal orderTotal = 0;
            order.OrderPlaced = DateTime.Now;

            _db.Orders.Add(order);

            var cartItems = GetShoppingCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var shoppingCartItem in cartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    DrinkId = shoppingCartItem.Drink.DrinkId,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Drink.Price
                };

                // Set the order total of the shopping cart
                orderTotal += (shoppingCartItem.Amount * shoppingCartItem.Drink.Price);
                _db.OrderDetails.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            order.OrderTotal = orderTotal;

            // Save the order
            _db.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
           
        }


        public void ClearCart()
        {
            var cartItems = _db
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _db.ShoppingCartItems.RemoveRange(cartItems);

            _db.SaveChanges();
        }


    }
}
    
    
