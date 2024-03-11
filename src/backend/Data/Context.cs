using Appointments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            modelBuilder.Entity<User>().ToTable("Appoint_T_User")
                .Property(u => u.Roles)
                .HasConversion(
                    u => string.Join(',', u),
                    u => u.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}
