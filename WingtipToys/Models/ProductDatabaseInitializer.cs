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
           return new List<Category>
            {
                Category.Of(1, "Cars"),
                Category.Of(2, "Planes"),
                Category.Of(3, "Trucks"),
                Category.Of(4, "Boats"),
                Category.Of(5, "Rockets"),
            };
        }

        private static List<Product> GetProducts()
        {
            return new List<Product>
            {
                Product.Of(1, "Convertible Car", "This convertible car is fast! The engine is powerd by a neutrino based battery (not included). Power it up and let it go!", "carconvert.png", 22.50, 1),
                Product.Of(2, "Old-time Car", "There's nothing old about this toy car, except it's looks. Compatible with other old toy cars.", "carearly.png", 15.95, 1),
                Product.Of(3, "Fast Car", "Yes this car is fast, but it also floats in water.", "carfast.png", 32.99, 1),
                Product.Of(4, "Super Fast Car", "Use this super fast car to entertain guests. Lights and doors work!", "carfaster.png", 8.95, 1),
                Product.Of(5, "Old Style Racer", "This old style racer can fly (with user assistance). Gravity controls flight duration. No batteries required.", "carracer.png", 34.95, 1),
                Product.Of(6, "Ace Plane", "Authentic airplane toy. Features realistic color and details.", "planeace.png", 95.00, 2),
                Product.Of(7, "Glider", "This fun glider is made from real balsa wood. Some assembly required.", "planeglider.png", 4.95, 2),
                Product.Of(8, "Paper Plane", "This paper plane is like no other paper plane. Some folding required.", "planepaper.png", 2.95, 2),
                Product.Of(9, "Propeller Plane", "Rubber band powered plane features two wheels.", "planeprop.png", 32.95, 2),
                Product.Of(10, "Early Truck", "This toy truck has a real gas powered engine. Requires regular tune ups.", "truckearly.png", 15.00, 3),
                Product.Of(11, "Fire Truck", "You will have endless fun with this one quarter sized fire truck.", "truckfire.png", 26.00, 3),
                Product.Of(12, "Big Truck", "This fun toy truck can be used to tow other trucks that are not as big.", "truckbig.png", 29.00, 3),
                Product.Of(13, "Big Ship", "Is it a boat or a ship. Let this floating vehicle decide by using its artifically intelligent computer brain!", "boatbig.png", 95.00, 4),
                Product.Of(14, "Paper Boat", "Floating fun for all! This toy boat can be assembled in seconds. Floats for minutes! Some folding required.", "boatpaper.png", 4.95, 4),
                Product.Of(15, "Sail Boat", "Put this fun toy sail boat in the water and let it go!", "boatsail.png", 42.95, 4),
                Product.Of(16, "Rocket", "This fun rocket will travel up to a height of 200 feet.", "rocket.png", 122.95, 5),
            };
        }
    }
}