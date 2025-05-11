using EmployeeManagement.DAL.RepositoryInterfaces;
using EmployeeManagement.DatabaseEntities.Models;

namespace EmployeeManagement.DAL.RepositoryImplementation
{
    internal class StateRepository : IStateRepository
    {
        public Task<bool> AddState(State state)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteState(Guid stateId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditState(State state)
        {
            throw new NotImplementedException();
        }

        public Task<List<State>> GetAllStates()
        {
            throw new NotImplementedException();
        }

        public Task<State> GetStateById(Guid stateId)
        {
            throw new NotImplementedException();
        }
    }
}
