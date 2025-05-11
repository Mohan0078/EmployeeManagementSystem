using EmployeeManagement.DatabaseEntities.Models;

namespace EmployeeManagement.DAL.RepositoryInterfaces
{
    public interface IStateRepository
    {
        Task<bool> AddState(State state);
        Task<bool> EditState(State state);
        Task<State> GetStateById(Guid stateId);
        Task<List<State>> GetAllStates();
        Task<bool> DeleteState(Guid stateId);
    }
}
