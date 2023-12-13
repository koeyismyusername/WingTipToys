using System.Collections.Generic;
using System.Data.Entity;

namespace WingtipToys.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(x => context.Categories.Add(x));
            GetProducts().ForEach(x => context.Products.Add(x));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category>
            {
                // TODO: GetCategories 메서드 완성하기
            }
        }
    }
}