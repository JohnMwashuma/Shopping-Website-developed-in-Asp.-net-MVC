using GrandLabFixers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrandLabFixers.ViewModels
{

    public class ShoppingCart : IDisposable
    {
        public ApplicationDbContext _Context;

        public ShoppingCart()
        {
            _Context = new ApplicationDbContext();
        }

        public decimal CartTotal { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public List<Product> Product { get; set; }

        public Product Products { get; set; }

        public List<Cart> Carts { get; set; }

        public const string CartSessionKey = "CartId";

        public string GetCardId()
        {
            
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] =
                         HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public int RemoveFromCart(int id)
        {
            string shoppingCartId = GetCardId();
            
            var cartItem = _Context.Carts.Single(
                cart => cart.CartId == shoppingCartId
                && cart.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    itemCount = cartItem.Quantity;
                }
                else
                {
                    _Context.Carts.Remove(cartItem);
                }
                // Save changes
                _Context.SaveChanges();
            }
            return itemCount;
        }

        public List<Cart> GetCartItems()
        {

            string shoppingCartId = GetCardId();
            return _Context.Carts.Where(
                cart => cart.CartId == shoppingCartId).ToList();
        }

        public decimal GetTotal()
        {
           string shoppingCartId = GetCardId();
            // Multiply product price by quantity of that product to get        
            // the current price for each of those products in the cart.  
            // Sum all product price totals to get the cart total.   
            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in _Context.Carts
                               where cartItems.CartId == shoppingCartId
                               select (int?)cartItems.Quantity).Sum();
            return total ?? decimal.Zero;
        }

        public void EmptyCart(string cartId)
        {
            cartId = GetCardId();
            var cartItems = _Context.Carts.Where(
                cart => cart.CartId == cartId);

            foreach (var cartItem in cartItems)
            {
                _Context.Carts.Remove(cartItem);
            }
            // Save changes
            _Context.SaveChanges();
        }

        public void MigrateCart(string cartid, string userName)
        {
            var shoppingCart = _Context.Carts.Where(c => c.CartId == cartid);
            foreach (var item in shoppingCart)
            {
                item.CartId = userName;
            }
            HttpContext.Current.Session[CartSessionKey] = userName;
            _Context.SaveChanges();
        }

        public void Dispose()
        {
            if (_Context != null)
            {
                _Context.Dispose();
                _Context = null;
            }
        }

       
    }
}