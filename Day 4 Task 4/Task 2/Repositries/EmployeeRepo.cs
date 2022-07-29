using WebApplication6.Models;

namespace WebApplication6.Repositries
{
    public class EmployeeRepo : IEmployeeRepo
    {
         
        
        EmpDbContext _context;

        public EmployeeRepo(EmpDbContext context)
        {
            _context = context;
        }

        public void AddEmployee(Employee obj)
        {
            _context.Employees.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee obj = _context.Employees.Find(id);
            _context.Employees.Remove(obj);
            _context.SaveChanges();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> stList = _context.Employees.ToList();
            return stList;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee obj = _context.Employees.Find(id);
            return obj;
        }


        public IEnumerable<Employee> GetAllEmployeeByDeptno(int Deptno)
        {
           IEnumerable<Employee> stList= _context.Employees.Where(item =>item.Deptno.Equals(Deptno));
            return stList;
        }

        public IEnumerable<Employee> GetAllEmployeeByJob(string Job)
        {
            IEnumerable<Employee> stList = _context.Employees.Where(item => item.Job.Equals(Job));
            return stList;
        }

        public void UpdateEmployee(Employee obj)
        {
            _context.Employees.Update(obj);
            _context.SaveChanges();
        }

    }

}