using Microsoft.EntityFrameworkCore;

namespace FisherImageProject.Models
{
    public class ImageTagContext : DbContext
    {
        public ImageTagContext(DbContextOptions<ImageTagContext> options) : base(options)
        {
        }

        public DbSet<ImageTag> ImageTags { get; set; } = null!;
    }
}
