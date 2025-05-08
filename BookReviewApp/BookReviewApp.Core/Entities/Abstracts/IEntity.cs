using BookReviewApp.Core.Enums;

namespace BookReviewApp.Core.Entities.Abstracts
{
    public interface IEntity
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
