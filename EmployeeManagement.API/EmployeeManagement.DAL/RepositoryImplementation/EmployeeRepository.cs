using EmployeeManagement.DAL.RepositoryInterfaces;
using EmployeeManagement.DatabaseEntities.Models;
using Microsoft.EntityFrameworkCore;

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

        public  async Task<bool> DeleteEmployee(Guid employeeId)
        {
            try
            {
                var employeeToBeDeleted = await _dbContext.Employees
                                                .FirstOrDefaultAsync(x => x.EmployeeId == employeeId 
                                                                    && x.IsDeleted == false);
                if(employeeToBeDeleted != null)
                {
                    employeeToBeDeleted.IsDeleted = true;
                    return await _dbContext.SaveChangesAsync() > 0;
                }

                return false; // Not able to delete as the data is not found
            }
            catch (Exception)
            {
                throw;
            }
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
