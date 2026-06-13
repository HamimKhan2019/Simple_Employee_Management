using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Authorize]  // ← ADD THIS
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            return Ok(_employeeService.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> AddEmployee([FromBody] Employee employee)
        {
            _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var existing = _employeeService.GetEmployeeById(id);
            if (existing == null)
                return NotFound();
            _employeeService.UpdateEmployee(id, employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound();
            _employeeService.DeleteEmployee(id);
            return NoContent();
        }

        [HttpPatch("{id}/salary")]
        public IActionResult UpdateSalary(int id, [FromBody] decimal newSalary)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound();
            
            employee.Salary = newSalary;
            return Ok(new { message = "Salary updated", newSalary = newSalary });
        }
    }
}
