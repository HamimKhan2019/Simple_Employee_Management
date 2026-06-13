using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _db;

        public EmployeeService(AppDbContext db)
        {
            _db = db;
        }

        public List<Employee> GetAllEmployees() => _db.Employees.ToList();

        public Employee? GetEmployeeById(int id) => _db.Employees.Find(id);

        public void AddEmployee(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
        }

        public void UpdateEmployee(int id, Employee updated)
        {
            var employee = GetEmployeeById(id);
            if (employee == null) return;

            employee.Name = updated.Name;
            employee.Email = updated.Email;
            employee.Department = updated.Department;
            employee.Salary = updated.Salary;
            _db.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if (employee == null) return;

            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}