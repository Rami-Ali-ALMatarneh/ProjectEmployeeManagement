using Microsoft.EntityFrameworkCore;
using ProjectEmployeeManagement.Extensions;
//using ProjectEmployeeManagement.Extensions;

using ProjectEmployeeManagement.Models;
using System.Numerics;

namespace ProjectEmployeeManagement.Data
    {
    public class AppDbContext:DbContext
        {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<Employee> Employee { get; set; }
      protected override void OnModelCreating( ModelBuilder modelBuilder )
            {
            modelBuilder.SeedEmployee();
            }
        }
    
    
    }
