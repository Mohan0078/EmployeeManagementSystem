using EmployeeManagement.DAL.RepositoryInterfaces;
using EmployeeManagement.DatabaseEntities.Models;

namespace EmployeeManagement.DAL.RepositoryImplementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<bool> AddEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeById(Guid employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
