using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace WingtipToys.Models
{
    [Table(Name = "CartItem")]
    public class CartItem
    {
        [Column(Name = "itemId", CanBeNull = false, DbType = "nvarchar(300)", IsPrimaryKey = true)]
        public string ItemId { get; private set; }

        [Column(Name = "cartId", CanBeNull = false, DbType = "nvarchar(300)")]
        public string CartId { get; private set; }

        [Column(Name = "quantity", CanBeNull = false, DbType = "int")]
        public int Quantity { get; private set; }

        [Column(Name = "createdAt", CanBeNull = false, DbType = "datetime", IsDbGenerated = true)]
        public DateTime DateCreated { get; private set; }

        [Column(Name = "productId", CanBeNull = false, DbType = "int")]
        public int ProductId { get; private set; }
        
        public static CartItem Of(string itemId, string cartId, int quantity, int productId)
        {
            return new CartItem
            {
                ItemId = itemId,
                CartId = cartId,
                Quantity = quantity,
                ProductId = productId,
            };
        }

        public void IncreaseQuantity(int increaseAmount)
        {
            Quantity += increaseAmount;
        }
    }
}