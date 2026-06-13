using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee? GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(int id, Employee employee);
        void DeleteEmployee(int id);
    }
}