using System.ComponentModel.DataAnnotations;

namespace WingtipToys.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductID { get; private set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string ProductName { get; private set; }

        [Required, StringLength(10000), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        public string Description { get; private set; }

        public string ImagePath { get; private set; }

        [Display(Name = "Price")]
        public double? UnitPrice { get; private set; }

        public int? CategoryID { get; private set; }

        public virtual Category Category { get; private set; }
    }
}