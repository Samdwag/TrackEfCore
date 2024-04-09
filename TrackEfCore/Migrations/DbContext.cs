using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data.Common;

namespace TrackEfCore
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<TrackResult> TrackResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=BEAST;Initial Catalog=TrackMeetFramework;Integrated Security=True;Pooling=False;Encrypt=False;");
        }
    }
}
