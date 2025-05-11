using EmployeeManagement.DAL.RepositoryInterfaces;
using EmployeeManagement.DatabaseEntities.Models;

namespace EmployeeManagement.DAL.RepositoryImplementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly employeemanagementContext _dbContext;

        public EmployeeRepository(employeemanagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddEmployeeAsync(Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
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
