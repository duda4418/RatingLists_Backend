namespace RatingLists_Backend.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ListId { get; set; }
        public required string Name { get; set; }
        public required string ItemType { get; set; }
        public string? Description { get; set; }
        public string? BlobUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? DeletedExpiresAt { get; set; }

        public User? User { get; set; }
        public RatingList? List { get; set; }
        public ICollection<ItemRating> ItemRatings { get; set; } = new List<ItemRating>();
    }
}
