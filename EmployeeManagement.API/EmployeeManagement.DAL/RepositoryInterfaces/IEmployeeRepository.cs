using EmployeeManagement.DatabaseEntities.Models;

namespace EmployeeManagement.DAL.RepositoryInterfaces
{
    public interface IEmployeeRepository
    {
        Task<bool> AddEmployeeAsync(Employee employee);
        Task<bool> EditEmployee(Employee employee);
        Task<Employee> GetEmployeeById(Guid employeeId);
        Task<List<Employee>> GetAllEmployees();
        Task<bool> DeleteEmployee(Guid employeeId);
    }
}
