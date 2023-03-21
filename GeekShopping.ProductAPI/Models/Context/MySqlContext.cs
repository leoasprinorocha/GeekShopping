using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {

        }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Boneco Pantera Negra",
                Description = "Description",
                Price = new decimal(500.90),
                CategoryName = "Boneco",
                ImageUrl = "https://github.com/leoasprinorocha/GeekShopping/blob/master/GeekShopping.Web/Images/homemaranha.jpg?raw=true"
            },
            new Product
            {
                Id = 3,
                Name = "Boneco Capitão América",
                Description = "Description",
                Price = 500,
                CategoryName = "Boneco",
                ImageUrl = "https://github.com/leoasprinorocha/GeekShopping/blob/master/GeekShopping.Web/Images/homemaranha.jpg?raw=true"
            });
        }

    }
}
