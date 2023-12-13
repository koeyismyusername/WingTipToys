using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WingtipToys.Models
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int CategoryID { get; private set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string CategoryName { get; private set; }

        [Display(Name = "Product Description")]
        public string Description { get; private set; }

        public virtual ICollection<Product> Products { get; private set; }
    }
}