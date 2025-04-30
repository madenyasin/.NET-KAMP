using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManyToMany.Models.Configurations
{
    public class KitapConfiguration : IEntityTypeConfiguration<Kitap>
    {
        public void Configure(EntityTypeBuilder<Kitap> builder)
        {
            builder.HasData(
                 new Kitap { Id = 1, Ad = "Kara Kitap", ISBN = "978-975-08-0197-8", Ozet = "" },
                new Kitap { Id = 2, Ad = "İnce Memed", ISBN = "978-975-08-0669-0", Ozet = "" },
                new Kitap { Id = 3, Ad = "Kürk Mantolu Madonna", ISBN = "978-975-08-0870-0" , Ozet = "" }
                );
        }
    }
}
