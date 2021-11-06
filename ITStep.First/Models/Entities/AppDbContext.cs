using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ITStep.First.Models.Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AppDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasIndex(r => r.Name).IsUnique();
            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany(r => r.Users).UsingEntity<UserRoles>(
                j => j.HasOne(jt => jt.Role).WithMany(t => t.RoleUsers).HasForeignKey(p => p.RoleId),
                j => j.HasOne(jt => jt.User).WithMany(t => t.UserRoles).HasForeignKey(r => r.UserId),
                j =>
                {
                    j.HasKey(t => new { t.UserId, t.RoleId });
                    j.ToTable("UserRoles");
                });

            modelBuilder.Entity<Role>().HasData(
                new Role[]
                {
                    new Role { Id = 1, Name = "Admins", Description = "Site administrator" },
                    new Role { Id =2, Name = "Authors", Description = "Blog Authors" }
            });

            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Login = "Admin",
                Locked = false,
                Secret = "12345678",
            });

            modelBuilder.Entity<UserRoles>().HasData(
                new UserRoles[] {
                    new UserRoles(){UserId = 1, RoleId = 1},
                    new UserRoles(){UserId = 1, RoleId = 2},
                });
        }
    }
}
