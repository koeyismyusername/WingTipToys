using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace WingtipToys.Models
{
    [Table(Name = "Categories")]
    public class Category
    {
        [Column(Name ="seq", CanBeNull = false, DbType ="int", IsDbGenerated = true, IsPrimaryKey = true)]
        public int CategoryID { get; private set; }

        [Column(Name ="name", CanBeNull = false, DbType ="nvarchar(100)")]
        public string CategoryName { get; private set; }

        [Column(Name ="description", DbType ="nvarchar(4000)")]
        public string Description { get; private set; }

        public static Category Of(int categoryId, string categoryName)
        {
            return new Category
            {
                CategoryID = categoryId,
                CategoryName = categoryName,
            };
        }
    }
}