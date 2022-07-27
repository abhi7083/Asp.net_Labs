using WebApplication4.Models;

namespace WebApplication5.Repositries
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
            _context.emps.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee obj = _context.emps.Find(id);
            _context.emps.Remove(obj);
            _context.SaveChanges();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> stList = _context.emps.ToList();
            return stList;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee obj = _context.emps.Find(id);
            return obj;
        }

        public void UpdateEmployee(Employee obj)
        {
            _context.emps.Update(obj);
            _context.SaveChanges();
        }
    }
}