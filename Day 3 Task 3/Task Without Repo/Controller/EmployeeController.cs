using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Employee> stList = _context.emps.ToList();
            return View(stList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            _context.emps.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Employee obj = _context.emps.Find(id);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee obj = _context.emps.Find(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            _context.emps.Update(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj = _context.emps.Find(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deleteconfirm(int id)
        {
            Employee obj = _context.emps.Find(id);
            _context.emps.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
