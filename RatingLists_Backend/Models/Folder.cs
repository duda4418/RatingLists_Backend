namespace RatingLists_Backend.Models
{
    public class Folder
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public required string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? DeletedExpiresAt { get; set; }

        public User? User { get; set; }
        public ICollection<RatingList> Lists { get; set; } = new List<RatingList>();
    }
}
