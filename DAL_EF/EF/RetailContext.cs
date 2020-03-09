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
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                        .HasKey(t => t.ProductId);
            modelBuilder.Entity<Category>()
                        .HasKey(c => c.CategoryId);
            modelBuilder.Entity<Supplier>()
                        .HasKey(s => s.SupplierId);


            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Category)
                        .WithMany(c => c.Products)
                        .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Category>()
                        .HasMany(c => c.Products)
                        .WithOne(p => p.Category)
                        .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<ProductSupplier>()
                        .HasKey(ps => new {ps.ProductId, ps.SupplierId});
            modelBuilder.Entity<ProductSupplier>()
                        .HasOne(ps => ps.Product)
                        .WithMany(p => p.ProductSuppliers)
                        .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<ProductSupplier>()
                        .HasOne(ps => ps.Supplier)
                        .WithMany(s => s.ProductSuppliers)
                        .HasForeignKey(ps => ps.SupplierId);



        }
    }
}