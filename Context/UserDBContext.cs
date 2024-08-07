using Microsoft.EntityFrameworkCore;
using TravelDesk.Models;
using System;

namespace TravelDesk.Context
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Department> Departments { get; set; } 

        public DbSet<TravelRequest> TravelRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true },
                new Role { RoleId = 2, RoleName = "TravelAdmin", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true },
                new Role { RoleId = 3, RoleName = "Manager", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true },
                new Role { RoleId = 4, RoleName = "Employee", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true }
            );
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true },
                 new Department { DepartmentId = 2, DepartmentName = "HR", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true },
                  new Department { DepartmentId = 3, DepartmentName = "Admin", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true },
                   new Department { DepartmentId = 4, DepartmentName = "Travel", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true }

                );
        }
    }
}
