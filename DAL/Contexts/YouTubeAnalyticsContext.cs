using DAL.Constants;
using DAL.Enteties;
using Microsoft.EntityFrameworkCore;

namespace DAL.Contexts
{
    public class YouTubeAnalyticsContext : DbContext
    {
        public DbSet<ChannelStatisticsEntity> Channels { get; set; }
        public DbSet<VideoStatisticsEntity> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DataAccessConstants.ConnectionString);
        }
    }
}
