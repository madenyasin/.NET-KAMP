using BookReviewApp.Core.Entities.Concretes;
using BookReviewApp.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewApp.Infrastructure.Configurations
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            string authorId1 = "test-author-id-1";
            string authorId2 = "test-author-id-2";
            builder.HasData(
                new Author
                {
                    Id = authorId1,
                    FirstName = "George",
                    LastName = "Orwell",
                    CreatedAt = DateTime.UtcNow,
                    RecordStatus = RecordStatus.Inserted
                },
                new Author
                {
                    Id = authorId2,
                    FirstName = "Isaac",
                    LastName = "Asimov",
                    CreatedAt = DateTime.UtcNow,
                    RecordStatus = RecordStatus.Inserted
                }
            );
        }
    }
}
