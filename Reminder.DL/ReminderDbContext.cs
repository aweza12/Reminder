using Microsoft.EntityFrameworkCore;
using Reminder.DL.Entities;
using Reminder.DL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DL
{
    public class ReminderDbContext : DbContext
    {
        public ReminderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
            .HasData(
            new Role
            {
                Id = 1,
                Name = "SuperAdmin",
                GuardName = "SuperAdmin",
                CreatedAt = DateTime.Now
            },
            new Role
            {
                Id = 2,
                Name = "Admin",
                GuardName = "Admin",
                CreatedAt = DateTime.Now
            },
            new Role
            {
                Id = 3,
                Name = "User",
                GuardName = "User",
                CreatedAt = DateTime.Now
            });

            modelBuilder.Entity<User>()
            .HasData(
            new User
            {
                Id  = 1,
                Uuid = Guid.NewGuid(),
                Username = "SuperAdmin",
                FirstName = "SuperAdmin",
                LastName = "SuperAdmin",
                Email = "aweza12@gmail.com",
                PasswordHash = new byte[16],
                PasswordSalt = new byte[16],
                Active = 1,
                RoleId = 1,
                //Role = new Role() { }
                CreatedAt = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
