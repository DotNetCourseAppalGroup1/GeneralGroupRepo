using System.Collections.Generic;
using System.Data.Entity;
using ProductDatabase.Entity;

namespace ProductDatabase.DatabaseContext
{
    class DBInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext db)
            {
                List<Product> users = new List<Product>()
                {
                    new Product() { Name = "Tom", Category = "Down"},
                    new Product() { Name = "Tom2", Category = "Down"},
                    new Product() { Name = "Tom65", Category = "Do12wn"},
                    new Product() { Name = "Tom475", Category = "Dow1234n"},
                    new Product() { Name = "Tom2", Category = "Do1234wn"},
                };
                db.Products.AddRange(users);
                db.SaveChanges();
            }
        }
}
