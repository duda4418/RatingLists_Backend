namespace RatingLists_Backend.Models
{
    public class RatingList
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? FolderId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? BlobUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? DeletedExpiresAt { get; set; }

        public User? User { get; set; }
        public Folder? Folder { get; set; }
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public ICollection<ListRating> ListRatings { get; set; } = new List<ListRating>();
    }
}
