using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace WingtipToys.Models
{
    [Table(Name = "[dbo].[Products]")]
    public class Product
    {
        [Column(Name = "seq", CanBeNull = false, DbType = "int", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ProductID { get; private set; }

        [Column(Name = "name", CanBeNull = false, DbType = "nvarchar(100)")]
        public string ProductName { get; private set; }

        [Column(Name = "description", CanBeNull = false, DbType = "nvarchar(4000)")]
        public string Description { get; private set; }

        [Column(Name = "imageUrl", DbType = "nvarchar(max)")]
        public string ImagePath { get; private set; }

        [Column(Name = "unitPrice", CanBeNull = false, DbType = "float")]
        public double UnitPrice { get; private set; }

        [Column(Name = "categoryId", DbType = "int")]
        public int? CategoryID { get; private set; }

        public static Product Of(int productId, string productName, string description, string imagePath, double unitPrice, int categoryID)
        {
            return new Product
            {
                ProductID = productId,
                ProductName = productName,
                Description = description,
                ImagePath = imagePath,
                UnitPrice = unitPrice,
                CategoryID = categoryID,
            };
        }
    }
}