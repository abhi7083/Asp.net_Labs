using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models
{
    public class Employee
    {
    
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string Job { get; set; }
        public int Salary { get; set; }
        public int Deptno { get; set; }
    }

    public class EmpDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmpDbContext(DbContextOptions<EmpDbContext> options)
         : base(options)
        {

        }
    }
}
