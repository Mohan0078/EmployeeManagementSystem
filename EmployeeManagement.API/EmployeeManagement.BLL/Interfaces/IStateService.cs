using EmployeeManagement.Models.ResponseModel;

namespace EmployeeManagement.BLL.Interfaces
{
    public interface IStateService
    {
        Task<List<StateResponseModel>> GetStateListAsync();
    }
}
