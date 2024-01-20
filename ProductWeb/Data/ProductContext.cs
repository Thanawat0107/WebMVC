using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductWeb.Models;

namespace ProductWeb.Data
{
    public class ProductContext : IdentityDbContext
    {
        public  ProductContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SqlExpress; Database=ProductWeb; Trusted_Connection=True; TrustServerCertificate=True");
        }

        public DbSet<User> Users {  get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}