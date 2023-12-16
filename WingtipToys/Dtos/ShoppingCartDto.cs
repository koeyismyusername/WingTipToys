using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WingtipToys.Models;

namespace WingtipToys.Dtos
{
    public class ShoppingCartDto
    {
        public string ItemId { get; private set; }
        public string CartId { get; private set; }
        public int Quantity { get; private set; }
        public DateTime DateCreated { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }

        public static ShoppingCartDto Of(CartItem cartItem, Product product)
        {
            return new ShoppingCartDto
            {
                ItemId = cartItem.ItemId,
                CartId = cartItem.CartId,
                Quantity = cartItem.Quantity,
                DateCreated = cartItem.DateCreated,
                ProductId = cartItem.ProductId,
                Product = product,
            };
        }
    }
}