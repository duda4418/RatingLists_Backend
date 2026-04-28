using Microsoft.EntityFrameworkCore;
using RatingLists_Backend.Models;

namespace RatingLists_Backend.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Folder> Folders => Set<Folder>();
        public DbSet<RatingList> Lists => Set<RatingList>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<ListRating> ListRatings => Set<ListRating>();
        public DbSet<ItemRating> ItemRatings => Set<ItemRating>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id").HasColumnType("uuid");
                entity.Property(e => e.Email).HasColumnName("email").HasColumnType("character varying").IsRequired();
                entity.Property(e => e.Name).HasColumnName("name").HasColumnType("character varying").IsRequired();
                entity.Property(e => e.PasswordHash).HasColumnName("password_hash").HasColumnType("text").IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("timestamp");
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.ToTable("folders");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id").HasColumnType("uuid");
                entity.Property(e => e.UserId).HasColumnName("user_id").HasColumnType("uuid");
                entity.Property(e => e.Name).HasColumnName("name").HasColumnType("character varying").IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("timestamp");
                entity.Property(e => e.DeletedExpiresAt).HasColumnName("deleted_expires_at").HasColumnType("timestamp");

                entity.HasOne(e => e.User)
                    .WithMany(e => e.Folders)
                    .HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<RatingList>(entity =>
            {
                entity.ToTable("lists");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id").HasColumnType("uuid");
                entity.Property(e => e.UserId).HasColumnName("user_id").HasColumnType("uuid");
                entity.Property(e => e.FolderId).HasColumnName("folder_id").HasColumnType("uuid");
                entity.Property(e => e.Name).HasColumnName("name").HasColumnType("character varying").IsRequired();
                entity.Property(e => e.Description).HasColumnName("description").HasColumnType("text");
                entity.Property(e => e.BlobUrl).HasColumnName("blob_url").HasColumnType("text");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("timestamp");
                entity.Property(e => e.DeletedExpiresAt).HasColumnName("deleted_expires_at").HasColumnType("timestamp");

                entity.HasOne(e => e.User)
                    .WithMany(e => e.Lists)
                    .HasForeignKey(e => e.UserId);

                entity.HasOne(e => e.Folder)
                    .WithMany(e => e.Lists)
                    .HasForeignKey(e => e.FolderId);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id").HasColumnType("uuid");
                entity.Property(e => e.UserId).HasColumnName("user_id").HasColumnType("uuid");
                entity.Property(e => e.ListId).HasColumnName("list_id").HasColumnType("uuid");
                entity.Property(e => e.Name).HasColumnName("name").HasColumnType("character varying").IsRequired();
                entity.Property(e => e.ItemType).HasColumnName("item_type").HasColumnType("character varying").IsRequired();
                entity.Property(e => e.Description).HasColumnName("description").HasColumnType("text");
                entity.Property(e => e.BlobUrl).HasColumnName("blob_url").HasColumnType("text");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("timestamp");
                entity.Property(e => e.DeletedExpiresAt).HasColumnName("deleted_expires_at").HasColumnType("timestamp");

                entity.HasOne(e => e.User)
                    .WithMany(e => e.Items)
                    .HasForeignKey(e => e.UserId);

                entity.HasOne(e => e.List)
                    .WithMany(e => e.Items)
                    .HasForeignKey(e => e.ListId);
            });

            modelBuilder.Entity<ListRating>(entity =>
            {
                entity.ToTable("list_ratings");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id").HasColumnType("uuid");
                entity.Property(e => e.UserId).HasColumnName("user_id").HasColumnType("uuid");
                entity.Property(e => e.ListId).HasColumnName("list_id").HasColumnType("uuid");
                entity.Property(e => e.RatingValue).HasColumnName("rating_value").HasColumnType("decimal").IsRequired();
                entity.Property(e => e.Review).HasColumnName("review").HasColumnType("text");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("timestamp");

                entity.HasOne(e => e.User)
                    .WithMany(e => e.ListRatings)
                    .HasForeignKey(e => e.UserId);

                entity.HasOne(e => e.List)
                    .WithMany(e => e.ListRatings)
                    .HasForeignKey(e => e.ListId);
            });

            modelBuilder.Entity<ItemRating>(entity =>
            {
                entity.ToTable("item_ratings");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id").HasColumnType("uuid");
                entity.Property(e => e.UserId).HasColumnName("user_id").HasColumnType("uuid");
                entity.Property(e => e.ItemId).HasColumnName("item_id").HasColumnType("uuid");
                entity.Property(e => e.RatingValue).HasColumnName("rating_value").HasColumnType("decimal").IsRequired();
                entity.Property(e => e.Review).HasColumnName("review").HasColumnType("text");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("timestamp");

                entity.HasOne(e => e.User)
                    .WithMany(e => e.ItemRatings)
                    .HasForeignKey(e => e.UserId);

                entity.HasOne(e => e.Item)
                    .WithMany(e => e.ItemRatings)
                    .HasForeignKey(e => e.ItemId);
            });
        }
    }
}
