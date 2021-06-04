using Microsoft.EntityFrameworkCore;

namespace MeetingScheduler.Models
{
    public class MeetingsContext : DbContext
    {
        public MeetingsContext(DbContextOptions<MeetingsContext> options)
            : base(options)
        {
        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Attendant> Attendants { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Meeting>().HasMany(a => a.Attendants).WithOne(a => a.Meeting);
        }
    }
}
