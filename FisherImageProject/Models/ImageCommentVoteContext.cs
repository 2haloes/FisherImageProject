using Microsoft.EntityFrameworkCore;

namespace FisherImageProject.Models
{
    public class ImageCommentVoteContext : DbContext
    {
        public ImageCommentVoteContext(DbContextOptions<ImageCommentVoteContext> options) : base(options)
        {
        }

        public DbSet<ImageCommentVote> ImageCommentVotes { get; set; } = null!;
    }
}
