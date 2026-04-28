namespace RatingLists_Backend.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string PasswordHash { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<Folder> Folders { get; set; } = new List<Folder>();
        public ICollection<RatingList> Lists { get; set; } = new List<RatingList>();
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public ICollection<ListRating> ListRatings { get; set; } = new List<ListRating>();
        public ICollection<ItemRating> ItemRatings { get; set; } = new List<ItemRating>();
    }
}
