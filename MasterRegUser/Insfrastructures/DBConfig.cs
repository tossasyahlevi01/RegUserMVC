using MasterRegUser.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterRegUser.Insfrastructures
{
    public class DBConfig:DbContext
    {
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<UserAccountDetail> UserAccountDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var SQLCons = "Server=localhost;Database=DBRegUser;Integrated Security=True;TrustServerCertificate=Yes;";

            optionsBuilder.UseSqlServer(SQLCons);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>()
              .HasKey(e => e.UserNumber);
            modelBuilder.Entity<UserAccountDetail>()
             .HasKey(e => e.UserAccountDetailId);
        }
    }
}
