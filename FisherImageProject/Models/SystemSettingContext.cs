using Microsoft.EntityFrameworkCore;

namespace FisherImageProject.Models
{
    public class SystemSettingContext : DbContext
    {
        public SystemSettingContext(DbContextOptions<SystemSettingContext> options) : base(options)
        {
        }

        public DbSet<SystemSetting> SystemSettings { get; set; } = null!;
    }
}
