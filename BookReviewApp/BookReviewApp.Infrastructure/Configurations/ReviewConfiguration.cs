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
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            string appUserId = "test-user-id-1";
            string bookId1 = "test-book-id-1";
            string bookId2 = "test-book-id-2";
            string reviewId1 = "test-review-id-1";
            string reviewId2 = "test-review-id-2";
            builder.HasData(
            new Review
            {
                Id = reviewId1,
                BookId = bookId1,
                AppUserId = appUserId,
                Content = "Harika bir kitap",
                Rating = 5,
                CreatedAt = DateTime.UtcNow,
                RecordStatus = RecordStatus.Inserted
            },
                new Review
                {
                    Id = reviewId2,
                    BookId = bookId2,
                    AppUserId = appUserId,
                    Content = "Çok etkileyiciydi",
                    Rating = 4,
                    CreatedAt = DateTime.UtcNow,
                    RecordStatus = RecordStatus.Inserted
                }
            );
        }
    }
}
