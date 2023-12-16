using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WingtipToys.Models
{
    public class ProductContext : DbContext
    {
        private ProductContext() : base("WingtipToys")
        {

        }

        public static ProductContext New { get => new ProductContext(); }
        public DbSet<Category> Categories { get; private set; }
        public DbSet<Product> Products { get; private set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}