using EmployeeManagement.DatabaseEntities.Models;
using EmployeeManagement.Models.RequestModel;
using EmployeeManagement.Models.ResponseModel;

namespace EmployeeManagement.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> AddEmployeeAsync(AddEditEmployeeRequestModel addEditEmployeeRequestModel);
        Task<List<EmployeeResponseModel>> GetEmployeeListAsync();
        Task<bool> DeleteEmployeeByIdAsync(Guid employeeId);
        Task<bool> DeleteSelectedEmployeesAsync(List<Guid> employeeIds);
    }
}
