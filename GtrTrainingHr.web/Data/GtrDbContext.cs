using GtrTrainingHr.web.Models;
using Microsoft.EntityFrameworkCore;

namespace GtrTrainingHr.web.Models
{
    public class GtrDbContext : DbContext
    {
        public GtrDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Company> companies { get; set; }
        public DbSet<Designation> designations { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Shift> shifts { get; set; }  
        public DbSet<Employee> employees { get; set; }  
        public DbSet<AttendanceSummary> attendanceSummaries { get; set; }
        public DbSet<Attendance> attendances { get; set; }  
        public DbSet<Salary> salarys { get; set; }  

    }
}
