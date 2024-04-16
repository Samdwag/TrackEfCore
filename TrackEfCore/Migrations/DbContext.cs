using Microsoft.EntityFrameworkCore;

namespace TrackEfCore
{
    public class TrackContext : DbContext
    {
        public DbSet<TrackResult> TrackResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=BEAST;Database=TrackMeetFramework;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
