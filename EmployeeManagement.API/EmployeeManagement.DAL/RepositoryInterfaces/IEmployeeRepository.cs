using EmployeeManagement.DatabaseEntities.Models;

namespace EmployeeManagement.DAL.RepositoryInterfaces
{
    public interface IEmployeeRepository
    {
        Task<Guid> AddMemberAsync(Member member);
        Task<bool> AddEmployeeAsync(Employee employee);
        Task<bool> EditEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeByIdAsync(Guid employeeId);
        Task<List<Employee>> GetAllEmployeesAsync(string nameFilter=null);
        Task<bool> DeleteEmployeeByIdAsync(Guid employeeId);
        Task<bool> DeleteSelectedEmployeesAsync(List<Guid> employeeId);
    }
}
