using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Employee
    {
       
            public int EmpId { get; set; }

            [Required]
            public string EmpName { get; set; }
            public string Job { get; set; }
            public double Salary { get; set; }
            public int Deptno { get; set; }
    }
}
