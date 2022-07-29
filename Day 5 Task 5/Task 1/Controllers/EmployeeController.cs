using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmpDbContext _context;
        public EmployeeController(EmpDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var empList=await _context.Employees.ToListAsync();
            return Ok(empList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var empObj= await _context.Employees.FindAsync(id);

            if (empObj != null)
                return Ok(empObj);
            else
                return NotFound("Requested Employee Id Does not exist");
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee obj)
        {
            await _context.Employees.AddAsync(obj);
            await _context.SaveChangesAsync();
            return Ok("New Student details are added in database");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee obj)
        {
            _context.Employees.Update(obj);
            await _context.SaveChangesAsync();
            return Ok("Student details are updated in database.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var empObj = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(empObj);
            await _context.SaveChangesAsync();
            return Ok("Employee Details are Deleted");
        }
    }
}
