using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Tablo adı ve özellik konfigürasyonları
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .HasMaxLength(500);

            // Seed Data (Başlangıç verileri)
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Elektronik",
                    Description = "Teknoloji ürünleri"
                },
                new Category
                {
                    Id = 2,
                    Name = "Kitap",
                    Description = "Tüm kitap çeşitleri"
                }
            );
        }
    }
}
