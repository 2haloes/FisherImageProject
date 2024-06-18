using Microsoft.EntityFrameworkCore;

namespace FisherImageProject.Models
{
    public class TagBannedContext : DbContext
    {
        public TagBannedContext(DbContextOptions<TagBannedContext> options) : base(options)
        {
        }

        public DbSet<TagBanned> TagBanneds { get; set; } = null!;
    }
}
