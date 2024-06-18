using Microsoft.EntityFrameworkCore;

namespace FisherImageProject.Models
{
    public class ImageVoteContext : DbContext
    {
        public ImageVoteContext(DbContextOptions<ImageVoteContext> options) : base(options)
        {
        }

        public DbSet<ImageVote> ImageVotes { get; set; } = null!;
    }
}
