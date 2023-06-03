using Microsoft.EntityFrameworkCore;
using ProjectEmployeeManagement.Models;

namespace ProjectEmployeeManagement.Extensions
    {
    public static class ModelBuilderExtension
        {
        public static void SeedEmployee(this ModelBuilder modelBuilder )
            {
            modelBuilder.Entity<Employee>().HasData(new Employee
                {
                Id = 1,
                Name = "Rami",
                Email = "Example20@gmail.com",
                department = Department.SoftwareDevelopment,
                Phone = "774574645"
                });
            modelBuilder.Entity<Employee>().HasData(new Employee
                {
                Id = 2,
                Name = "Ali",
                Email = "Example21@gmail.com",
                department = Department.QualityAssurance,
                Phone = "772451639",

                });
            modelBuilder.Entity<Employee>().HasData(new Employee
                {
                Id = 3,
                Name = "Doha",
                Email = "Example22@gmail.com",
                department = Department.ITOperations,
                Phone = "774574222",
                });
            }
        }
    }
