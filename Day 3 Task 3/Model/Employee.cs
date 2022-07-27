using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Employee
    {
        [Key]
        public int Empid { get; set; }
        public string Ename { get; set; }
        public string Ejob { get; set; }
        public int Esal { get; set; }
        public int Edeptno { get; set; }
    }

    public class EmpDbContext : DbContext
    {
        public DbSet<Employee> emps { get; set; }

        public EmpDbContext(DbContextOptions<EmpDbContext> options)
         : base(options)
        {

        }
    }
}