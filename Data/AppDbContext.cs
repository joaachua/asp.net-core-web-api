using Microsoft.EntityFrameworkCore;
using NmqPracticeApi.Models;

namespace NmqPracticeApi.Data;

public sealed class AppDbContext(
    DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    public DbSet<ProductCategory> ProductCategories
        => Set<ProductCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var product = modelBuilder.Entity<Product>();

        product.ToTable("products");

        product.HasKey(p => p.Id);

        product.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        product.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        product.Property(p => p.Description)
            .HasMaxLength(500);

        product.Property(p => p.Price)
            .HasPrecision(18, 2);

        product.Property(p => p.Stock)
            .IsRequired();

        product.Property(p => p.ProductCategoryId)
            .IsRequired();

        product.HasOne(p => p.ProductCategory)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.ProductCategoryId);

        product.Property(p => p.CreatedAt)
            .IsRequired();

        product.HasCheckConstraint(
            "CK_Products_Price_Positive",
            "\"Price\" > 0");

        product.HasCheckConstraint(
            "CK_Products_Stock_NonNegative",
            "\"Stock\" >= 0");
        
        var category = modelBuilder.Entity<ProductCategory>();

        category.ToTable("product_categories");

        category.HasKey(c => c.Id);

        category.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        category.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
            }
}