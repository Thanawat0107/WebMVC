using Microsoft.EntityFrameworkCore;

namespace P04_RelationDB.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SqlExpress; Database=TestDB55; Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //กำหมด Primary
            modelBuilder.Entity<ComPonentProduct>().HasKey(k=>new {k.ProductId,k.ComponentId});
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ComPonent> ComPonents { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<ComPonentProduct> ComPonentProducts { get; set; }

    }
}
