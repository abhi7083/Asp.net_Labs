using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;
using System.Diagnostics;
using WebApplication6.Repositries;
using log4net;

namespace WebApplication6.Controllers
{
    //C:\Users\Administrator\source\repos\WebApplication6\WebApplication6\bin\Debug\net6.0\log4net.txt
    public class EmployeeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        IEmployeeRepo _employee;
        public EmployeeController(IEmployeeRepo employee, ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        IEmployeeRepo _repository;

        public EmployeeController(IEmployeeRepo repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        { 
         
            return View();
        }
      
        public IActionResult GetAllEmployees()
        {
            _logger.LogInformation("All Employee Action is Processed.");
            List<Employee> employee = _employee.GetAllEmployees();
            return View(employee);
        }
        [HttpGet]
       
        public IActionResult Create()
        {
            _logger.LogInformation("Details Action is Processed.");

            return View();
        }

        [HttpPost]
       
        public IActionResult Create(Models.Employee obj)
        {
            _logger.LogInformation("Create Post Action is Processed.");
            _repository.AddEmployee(obj);
            return RedirectToAction("Index");
        }
      
        public IActionResult Details(int id)
        {
            _logger.LogInformation("Details Action is Processed.");
            Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }


        [HttpGet]
    
        public IActionResult Edit(int id)
        {
            _logger.LogInformation("Details Action is Processed.");
            Models.Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
     
        public IActionResult Edit(Models.Employee obj)
        {
            _logger.LogInformation("Details Action is Processed.");
            _repository.UpdateEmployee(obj);
            return RedirectToAction("Index");
        }


        [HttpGet]

        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Details Action is Processed.");
            Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]

        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _logger.LogInformation("Details Action is Processed.");
            _repository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
  
        public IActionResult EmployeeByDeptno(int id)
        {
            _logger.LogInformation("Details Action is Processed.");
            return View();
        }

        [HttpPost]
   
        [ActionName("employeeByDeptNo")]
        public IActionResult GetAllEmployeeByDeptno(int Deptno)
        {
            _logger.LogInformation("Details Action is Processed.");
            IEnumerable<Employee> stList = _repository.GetAllEmployeeByDeptno(Deptno);
            ViewBag.RequestType = Request.Method;
            return View(stList);
        }

        [HttpGet]
   
        public IActionResult EmployeeByJob(string Job)
        {
            _logger.LogInformation("Details Action is Processed.");
            return View();
        }
        [HttpPost]
 
        [ActionName("employeeByJob")]
        public IActionResult GetAllEmployeeByJob(string Job)
        {
            _logger.LogInformation("Details Action is Processed.");
            IEnumerable<Employee> stList = _repository.GetAllEmployeeByJob(Job);
            ViewBag.RequestType = Request.Method;
            return View(stList);
        }

    }
}
