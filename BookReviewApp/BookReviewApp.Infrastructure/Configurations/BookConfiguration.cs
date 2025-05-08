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
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            string bookId1 = "test-book-id-1";
            string bookId2 = "test-book-id-2";
            string authorId1 = "test-author-id-1";
            string authorId2 = "test-author-id-2";
            string categoryId1 = "test-category-id-1";
            string categoryId2 = "test-category-id-2";

            builder.HasData(
                new Book
                {
                    Id = bookId1,
                    Title = "1984",
                    CategoryId = categoryId1,
                    CreatedAt = DateTime.UtcNow,
                    RecordStatus = RecordStatus.Inserted
                },
                new Book
                {
                    Id = bookId2,
                    Title = "Ben, Robot",
                    CategoryId = categoryId2,
                    CreatedAt = DateTime.UtcNow,
                    RecordStatus = RecordStatus.Inserted
                }
            );
        }
    }
}
