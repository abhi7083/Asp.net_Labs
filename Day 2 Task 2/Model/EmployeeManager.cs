namespace WebApplication2.Models
{
    public class EmployeeManager
    {
        public static List<Employee> employee = new List<Employee>();
        public EmployeeManager()
        {
            employee = new List<Employee>()
            {
                new Employee(){EmpId=101,EmpName="Max",Job="Cloud Developer",Salary=45000,Deptno=10},
                new Employee(){EmpId=102,EmpName="Ray",Job="Developer",Salary=50000,Deptno=20},
                new Employee(){EmpId=103,EmpName="Levi",Job="Admin",Salary=35000,Deptno=10},
                new Employee(){EmpId=104,EmpName="Chris",Job="IT Trainee",Salary=65000,Deptno=30},
                new Employee(){EmpId=105,EmpName="Harry",Job="HR",Salary=25000,Deptno=30},
                new Employee(){EmpId=106,EmpName="Tom",Job="Intern",Salary=45000,Deptno=10}
            };

        }
        public List<Employee> GetAllDets()
        {
            return employee;
        }

        public Employee GetEmployeeById(int id)
        {
            return employee.Find(item => item.EmpId == id);
        }
        public void AddEmployee(Employee obj)
        {
            employee.Add(obj);
        }
        public void DeleteEmployee(int id)
        {
            Employee obj = employee.Find(item => item.EmpId == id);
            employee.Remove(obj);
        }
        public void UpdateEmployee(Employee updateObj)
        {
            Employee obj = employee.Find(item => item.EmpId == updateObj.EmpId);
            employee.Remove(obj);
            employee.Add(updateObj);
        }

    }
}
