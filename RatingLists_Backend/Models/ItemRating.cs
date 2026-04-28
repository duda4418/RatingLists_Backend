namespace RatingLists_Backend.Models
{
    public class ItemRating
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public double RatingValue { get; set; }
        public string? Review { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public User? User { get; set; }
        public Item? Item { get; set; }
    }
}
