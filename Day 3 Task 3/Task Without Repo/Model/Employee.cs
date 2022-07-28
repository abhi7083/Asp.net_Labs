using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Employee
    {
      
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string Job { get; set; }
        public int Salary { get; set; }
        public int Deptno { get; set; }
    }

    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> emps { get; set; }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {

        }
    }
}