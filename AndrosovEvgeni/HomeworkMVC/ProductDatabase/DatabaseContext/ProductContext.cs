using System.Data.Entity;
using ProductDatabase.Entity;

namespace ProductDatabase.DatabaseContext
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("DbConnection")
        { }

        static ProductContext()
        {
            Database.SetInitializer<ProductContext>(new DBInitializer());
        }

        public DbSet<Product> Products { get; set; }
    }
}
