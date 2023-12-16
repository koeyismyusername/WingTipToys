using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WingtipToys.Dtos;
using WingtipToys.Models;

namespace WingtipToys.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        private readonly WingtipToysDatabase wingTipToysDB = WingtipToysDatabase.New;
        public const string cartSessionKey = "CartId";

        public string ShoppingCartId { get; private set; }

        public void AddToCart(int productId)
        {
            var shoppingCartId = GetCartId();
            var cartItemTable = wingTipToysDB.GetTable<CartItem>();
            var cartItem = cartItemTable
                .Where(x => x.CartId.Equals(shoppingCartId) && x.ProductId.Equals(productId))
                .SingleOrDefault();

            if (cartItem is null)
            {
                cartItem = CartItem.Of(Guid.NewGuid().ToString(), shoppingCartId, 1, productId);
                cartItemTable.InsertOnSubmit(cartItem);
            }else
            {
                cartItem.IncreaseQuantity(1);
            }
            wingTipToysDB.SubmitChanges();
        }

        private string GetCartId()
        {
            if (HttpContext.Current.Session[cartSessionKey] is null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                    HttpContext.Current.Session[cartSessionKey] = HttpContext.Current.User.Identity.Name;
                else
                    HttpContext.Current.Session[cartSessionKey] = Guid.NewGuid().ToString();
            }

            return HttpContext.Current.Session[cartSessionKey].ToString();
        }

        public IQueryable<ShoppingCartDto> GetCartItems()
        {
            var shoppingCartId = GetCartId();

            return from cart in wingTipToysDB.GetTable<CartItem>()
                   where cart.CartId.Equals(shoppingCartId)
                   join product in wingTipToysDB.GetTable<Product>() on cart.ProductId equals product.ProductID
                   select ShoppingCartDto.Of(cart, product);
        }

        public void Dispose()
        {
            wingTipToysDB.Dispose();
        }

        ~ShoppingCartActions()
        {
            Dispose();
        }
    }
}