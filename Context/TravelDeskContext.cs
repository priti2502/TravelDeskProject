using Microsoft.EntityFrameworkCore;

using TravelDesk.Models;

namespace TravelDesk.Context
{
    public class TravelDeskContext:DbContext
    {
        public TravelDeskContext(DbContextOptions<TravelDeskContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AirBooking> AirBookings { get; set; }

        public DbSet<HotelBooking> HotelBookings { get; set; }


        public DbSet<Department> Departments { get; set; }

       


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
           
            modelBuilder.Entity<User>()
           .HasOne(u => u.Manager)
           .WithMany() // A user can have many subordinates, but a manager does not need a collection of subordinates
           .HasForeignKey(u => u.ManagerId)
           .OnDelete(DeleteBehavior.Restrict);

            // Configure the one-to-many relationship between User and Role
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            // Configure the one-to-many relationship between Employee and HotelBooking
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.HotelBookings)
                .WithOne(h => h.Employee)
                .HasForeignKey(h => h.EmployeeId);

            // Configure the one-to-many relationship between Employee and AirBooking
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.AirBookings)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId);

            base.OnModelCreating(modelBuilder);


        }

    }
    }
