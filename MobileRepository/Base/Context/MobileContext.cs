using Microsoft.EntityFrameworkCore;
using MobileRepository.Model;

namespace MobileRepository.Base.Context
{
    public class MobileContext : DbContext
    {
        public MobileContext(DbContextOptions<MobileContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>()
        .HasKey(r => r.Id);

            modelBuilder.Entity<UserRole>()
        .HasKey(r => r.Id);
            // Seed data for Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "User" },
                new Role { Id = 3, RoleName = "Manager" }
            );

            // Seed data for Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "admin",
                    EmailAddress = "admin@example.com",
                    Password = "admin@123",
                    HashedPassword = "",
                    Address = "23, ASV, Thoraipakkam",
                    MobileNumber = "95241223241",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now,

                }
            );
        }
    }
}
