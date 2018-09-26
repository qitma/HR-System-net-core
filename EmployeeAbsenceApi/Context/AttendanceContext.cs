using Microsoft.EntityFrameworkCore;
using EmployeeAttendanceApi.Models;

namespace EmployeeAttendanceApi.Context
{
    public class AttendanceContext : DbContext
    {
        public AttendanceContext(DbContextOptions<AttendanceContext> options):base(options)
        {

        }

        public DbSet<Role> Roles {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<AnnualLeavePermission> AnnualLeavePermissions {get;set;}
        public DbSet<OverTimePermission> OverTimePermissions {get;set;}
        public DbSet<Attendance> Attendances {get;set;}
        public DbSet<SickLeavePermission> SickLeavePermissions {get;set;}
        public DbSet<AnnualLeaveUser> AnnualLeaveUser {get;set;}
        public DbSet<UserRole> UserRoles {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.RoleId , ur.UserId});
            
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.Roles)
                .HasForeignKey(ur => ur.UserId);
        }
    }
}