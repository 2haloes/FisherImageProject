using Microsoft.EntityFrameworkCore;

namespace FisherImageProject.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<TagBanned> TagBanneds { get; set; } = null!;
        public DbSet<TagCategory> TagCategorys { get; set; } = null!;
        public DbSet<ImageTag> ImageTags { get; set; } = null!;
        public DbSet<ImageVote> ImageVotes { get; set; } = null!;
        public DbSet<ImageBookmark> ImageBookmarks { get; set; } = null!;
        public DbSet<ImageComment> ImageComments { get; set; } = null!;
        public DbSet<ImageCommentVote> ImageCommentVotes { get; set; } = null!;
        public DbSet<SystemSetting> SystemSettings { get; set; } = null!;
    }
}
