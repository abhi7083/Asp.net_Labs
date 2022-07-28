using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;
using System.Diagnostics;
using WebApplication6.Repositries;
using log4net;
using WebApplication6.filter;

namespace WebApplication6.Controllers
{
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

        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Index()
        {
           
            List<Employee> stList = _repository.GetAllEmployees();
            return View(stList);
        }
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult GetAllEmployees()
        {
            _logger.LogInformation("All Employee Action is Processed.");
            List<Employee> employee = _employee.GetAllEmployees();
            return View(employee);
        }
        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Create()
        {
            _logger.LogInformation("Details Action is Processed.");

            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Create(Models.Employee obj)
        {
            _logger.LogInformation("Create Post Action is Processed.");
            _repository.AddEmployee(obj);
            return RedirectToAction("Index");
        }
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Details(int id)
        {
            _logger.LogInformation("Details Action is Processed.");
            Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }


        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Edit(int id)
        {
            _logger.LogInformation("Details Action is Processed.");
            Models.Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Edit(Models.Employee obj)
        {
            _logger.LogInformation("Details Action is Processed.");
            _repository.UpdateEmployee(obj);
            return RedirectToAction("Index");
        }


        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Details Action is Processed.");
            Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _logger.LogInformation("Details Action is Processed.");
            _repository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult EmployeeByDeptno(int id)
        {
            _logger.LogInformation("Details Action is Processed.");
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        [ActionName("employeeByDeptNo")]
        public IActionResult GetAllEmployeeByDeptno(int Deptno)
        {
            _logger.LogInformation("Details Action is Processed.");
            IEnumerable<Employee> stList = _repository.GetAllEmployeeByDeptno(Deptno);
            ViewBag.RequestType = Request.Method;
            return View(stList);
        }

        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult EmployeeByJob(string Job)
        {
            _logger.LogInformation("Details Action is Processed.");
            return View();
        }
        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
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
