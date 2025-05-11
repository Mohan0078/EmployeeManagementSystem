using EmployeeManagement.DatabaseEntities.Models;

namespace EmployeeManagement.DAL.RepositoryInterfaces
{
    public interface IEmployeeRepository
    {
        Task<bool> AddEmployeeAsync(Employee employee);
        Task<bool> EditEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeByIdAsync(Guid employeeId);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<bool> DeleteEmployeeAsync(Guid employeeId);
    }
}
