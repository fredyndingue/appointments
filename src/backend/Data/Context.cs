using Appointments.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apointments.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Roles)
                .HasConversion(
                    u => string.Join(',', u),
                    u => u.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}
