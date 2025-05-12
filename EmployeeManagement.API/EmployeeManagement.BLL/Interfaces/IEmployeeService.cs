using EmployeeManagement.DatabaseEntities.Models;
using EmployeeManagement.Models.RequestModel;

namespace EmployeeManagement.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> AddEmployeeAsync(AddEditEmployeeRequestModel addEditEmployeeRequestModel);
    }
}
