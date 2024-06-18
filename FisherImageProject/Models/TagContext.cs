using Microsoft.EntityFrameworkCore;

namespace FisherImageProject.Models
{
    public class TagContext : DbContext
    {
        public TagContext(DbContextOptions<TagContext> options) : base(options)
        {
        }

        public DbSet<Tag> Tags { get; set; } = null!;
    }
}
