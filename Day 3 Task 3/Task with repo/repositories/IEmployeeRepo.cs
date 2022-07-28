using WebApplication4.Models;

namespace WebApplication5.Repositries
{

    public interface IEmployeeRepo
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee obj);
        void UpdateEmployee(Employee obj);
        void DeleteEmployee(int id);
    }
}