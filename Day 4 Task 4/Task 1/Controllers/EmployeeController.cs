using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;
using System.Diagnostics;
using WebApplication6.Repositries;
using log4net;

namespace WebApplication6.Controllers
{
 
    public class EmployeeController : Controller
    {
        
        IEmployeeRepo _repository;

        public EmployeeController(IEmployeeRepo repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        { 
           List<Employee> stList = _repository.GetAllEmployees();
            return View(stList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Employee obj)
        {
         
            _repository.AddEmployee(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
           
            Models.Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Models.Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Models.Employee obj)
        {
            _repository.UpdateEmployee(obj);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Models.Employee obj = _repository.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _repository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EmployeeByDeptno(int id)
        {
            return View();
        }

        [HttpPost]
        [ActionName("employeeByDeptNo")]
        public IActionResult GetAllEmployeeByDeptno(int Deptno)
        {
           IEnumerable<Employee> stList = _repository.GetAllEmployeeByDeptno(Deptno);
            ViewBag.RequestType = Request.Method;
            return View(stList);
        }

        [HttpGet]
        public IActionResult EmployeeByJob(string Job)
        {
            return View();
        }
        [HttpPost]
        [ActionName("employeeByJob")]
        public IActionResult GetAllEmployeeByJob(string Job)
        {
            IEnumerable<Employee> stList = _repository.GetAllEmployeeByJob(Job);
            ViewBag.RequestType = Request.Method;
            return View(stList);
        }

    }
}
