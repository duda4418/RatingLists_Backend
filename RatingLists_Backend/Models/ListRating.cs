namespace RatingLists_Backend.Models
{
    public class ListRating
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ListId { get; set; }
        public decimal RatingValue { get; set; }
        public string? Review { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public User? User { get; set; }
        public RatingList? List { get; set; }
    }
}
