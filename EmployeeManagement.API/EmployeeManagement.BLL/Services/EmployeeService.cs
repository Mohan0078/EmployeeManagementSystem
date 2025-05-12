using EmployeeManagement.BLL.Interfaces;
using EmployeeManagement.DAL.RepositoryInterfaces;
using EmployeeManagement.DatabaseEntities.Models;
using EmployeeManagement.Models.RequestModel;
using EmployeeManagement.Models.ResponseModel;

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
				var addMemberResult = await _employeeRepository.AddMemberAsync(new Member
				{
					MemberId = Guid.NewGuid(),
					Name = addEditEmployeeRequestModel.Name,
					Gender = addEditEmployeeRequestModel.Gender,
					DateOfBirth = addEditEmployeeRequestModel.DateOfBirth,
					IsDeleted = false
				});

				addEditEmployeeRequestModel.MemberId = addMemberResult;
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
				IsDeleted = false,
				MemberId = addEditEmployeeRequestModel.MemberId,
				Salary = addEditEmployeeRequestModel.Salary,
				StateId = addEditEmployeeRequestModel.StateId
			};
		}

        public async Task<List<EmployeeResponseModel>> GetEmployeeListAsync()
        {
			try
			{
				var allEmployees = await _employeeRepository.GetAllEmployeesAsync();

				return allEmployees.Select(x => new EmployeeResponseModel
				{
				  EmployeeId = x.EmployeeId,
				  DateOfJoin = x.DateOfJoin,
				  DateOfBirth = x.Member.DateOfBirth,
				  Name = x.Member.Name,
				  Gender = x.Member.Gender,
				  Designation = x.Designation,
				  MemberId = x.MemberId,
				  Salary = x.Salary,
				  StateId = x.StateId,
				  StateName = x.State.StateName
				}).ToList();
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
