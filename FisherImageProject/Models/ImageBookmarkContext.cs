using Microsoft.EntityFrameworkCore;

namespace FisherImageProject.Models
{
    public class ImageBookmarkContext : DbContext
    {
        public ImageBookmarkContext(DbContextOptions<ImageBookmarkContext> options) : base(options)
        {
        }

        public DbSet<ImageBookmark> ImageBookmarks { get; set; } = null!;
    }
}
