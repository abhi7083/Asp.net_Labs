using WebApplication6.Models;

namespace WebApplication6.Repositries
{

    public interface IEmployeeRepo
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee obj);
        void UpdateEmployee(Employee obj);
        void DeleteEmployee(int id);
        IEnumerable<Employee> GetAllEmployeeByDeptno(int Deptno);
        IEnumerable<Employee> GetAllEmployeeByJob(string Job);
    }

}