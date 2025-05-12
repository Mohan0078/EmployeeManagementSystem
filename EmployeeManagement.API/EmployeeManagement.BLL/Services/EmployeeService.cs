using EmployeeManagement.BLL.Interfaces;
using EmployeeManagement.DAL.RepositoryInterfaces;
using EmployeeManagement.DatabaseEntities.Models;
using EmployeeManagement.Models.RequestModel;

namespace EmployeeManagement.BLL.Services
{
	public class EmployeeService : IEmployeeService
    {
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeeService(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		public async Task<bool> AddEmployeeAsync(AddEditEmployeeRequestModel addEditEmployeeRequestModel)
        {
			try
			{
				var employee = await BuildEmployeeRecord(addEditEmployeeRequestModel);

				return await _employeeRepository.AddEmployeeAsync(employee);
			}
			catch (Exception)
			{
				throw;
			}
        }

		private async Task<Employee> BuildEmployeeRecord(AddEditEmployeeRequestModel addEditEmployeeRequestModel)
		{
			return new Employee
			{
			  EmployeeId = addEditEmployeeRequestModel.EmployeeId == null ? Guid.NewGuid() : addEditEmployeeRequestModel.EmployeeId.Value,
			  DateOfJoin = addEditEmployeeRequestModel.DateOfJoin,
			  Designation = addEditEmployeeRequestModel.Designation,
			  IsDeleted = addEditEmployeeRequestModel.IsDeleted,
			  MemberId = addEditEmployeeRequestModel.MemberId,
			  Salary = addEditEmployeeRequestModel.Salary,
			  StateId = addEditEmployeeRequestModel.StateId
            }
		}
    }
}
