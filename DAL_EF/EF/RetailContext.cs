using Microsoft.EntityFrameworkCore;
using DAL_EF.Entities;

namespace DAL_EF.EF
{
    public class RetailContext : DbContext
    {
        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Supplier> Suppliers {get; set;}
        public DbSet<ProductSupplier> ProductSuppliers {get; set;}
        public RetailContext(DbContextOptions<RetailContext> options):
                base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .HasKey(t => t.Id);
            modelBuilder.Entity<Category>()
                        .HasKey(c => c.Id);
            modelBuilder.Entity<Supplier>()
                        .HasKey(s => s.Id);

            modelBuilder.Entity<Product>()
                        .HasOne<Category>(p => p.Category)
                        .WithMany(c => c.Products)
                        .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<ProductSupplier>()
                        .HasKey(ps => new {ps.ProductId, ps.SupplierId});
        }
    }
}