using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Tablo adı ve özellik konfigürasyonları
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Price)
                .HasPrecision(18, 2); // Decimal hassasiyet

            // Seed Data (Başlangıç verileri)
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "iPhone 15",
                    Price = 45000.99m,
                    Stock = 50,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Dünya Klasikleri Seti",
                    Price = 299.90m,
                    Stock = 100,
                    CategoryId = 2
                }
            );
        }
    }
}
