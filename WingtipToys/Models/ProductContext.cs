using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WingtipToys.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("WingtipToys")
        {

        }

        public DbSet<Category> Categories { get; private set; }
        public DbSet<Product> Products { get; private set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}