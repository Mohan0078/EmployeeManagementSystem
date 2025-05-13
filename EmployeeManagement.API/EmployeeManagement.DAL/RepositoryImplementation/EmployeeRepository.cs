using EmployeeManagement.DAL.RepositoryInterfaces;
using EmployeeManagement.DatabaseEntities.Models;
using LinqKit;
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

        public async Task<Guid> AddMemberAsync(Member member)
        {
            try
            {
                _dbContext.Members.Add(member);
                var isSaved = await _dbContext.SaveChangesAsync() > 0;
                return isSaved ? member.MemberId : Guid.Empty;
            }
            catch (Exception)
            {
                throw;
            }
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

        public async Task<bool> DeleteEmployeeByIdAsync(Guid employeeId)
        {
            try
            {
                var employeeToBeDeleted = await _dbContext.Employees
                                                .Include(x => x.Member)
                                                .FirstOrDefaultAsync(x => x.EmployeeId == employeeId
                                                                    && x.IsDeleted == false
                                                                    && x.Member != null);
                if (employeeToBeDeleted != null)
                {
                    employeeToBeDeleted.IsDeleted = true;
                    employeeToBeDeleted.Member.IsDeleted = true;
                    return await _dbContext.SaveChangesAsync() > 0;
                }

                return false; // Not able to delete as the data is not found
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> EditEmployeeAsync(Employee employee)
        {
            try
            {
                if (employee == null)
                    return false;

                var isEmployeeExist = await _dbContext.Employees
                                                      .AnyAsync(x => x.EmployeeId == employee.EmployeeId
                                                                     && x.IsDeleted == false);
                if (isEmployeeExist)
                {
                    _dbContext.Update(employee);
                    return await _dbContext.SaveChangesAsync() > 0;
                }

                return false; // if data not found
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Employee>> GetAllEmployeesAsync(string nameFilter = null)
        {
            try
            {
                var employeeSearchPredicate = PredicateBuilder.New<Employee>(x => x.IsDeleted == false 
                                                                                  && x.Member != null 
                                                                                  && x.State != null);
                if(nameFilter != "" && nameFilter != null && nameFilter != "null")
                {
                    employeeSearchPredicate = employeeSearchPredicate.And(x => x.Member.Name.Contains(nameFilter));
                }

                return await _dbContext.Employees
                             .Include(x => x.Member)
                             .Include(x => x.State)
                             .Where(employeeSearchPredicate)
                             .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
        {
            try
            {
                return await _dbContext.Employees
                             .FirstOrDefaultAsync(x => x.EmployeeId == employeeId
                                                       && x.IsDeleted == false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteSelectedEmployeesAsync(List<Guid> employeeIds)
        {
            try
            {
                var employeesToBeDeleted = await _dbContext.Employees
                                                    .Include(x => x.Member)
                                                    .Where(x => employeeIds.Contains(x.EmployeeId)
                                                                && x.IsDeleted == false
                                                                && x.Member != null).ToListAsync();
                if (employeesToBeDeleted.Any())
                {
                    foreach (var employeeToBeDeleted in employeesToBeDeleted)
                    {
                        employeeToBeDeleted.IsDeleted = true;
                        employeeToBeDeleted.Member.IsDeleted = true;
                    }
                    return await _dbContext.SaveChangesAsync() > 0;
                }

                return false; // Not able to delete as the data is not found
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
