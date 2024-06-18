using Microsoft.EntityFrameworkCore;

namespace FisherImageProject.Models
{
    public class ImageCommentContext : DbContext
    {
        public ImageCommentContext(DbContextOptions<ImageCommentContext> options) : base(options)
        {
        }

        public DbSet<ImageComment> ImageComments { get; set; } = null!;
    }
}
