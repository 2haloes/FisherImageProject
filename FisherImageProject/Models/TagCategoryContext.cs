using Microsoft.EntityFrameworkCore;

namespace FisherImageProject.Models
{
    public class TagCategoryContext : DbContext
    {
        public TagCategoryContext(DbContextOptions<TagCategoryContext> options) : base(options)
        {
        }

        public DbSet<TagCategory> TagCategorys { get; set; } = null!;
    }
}
