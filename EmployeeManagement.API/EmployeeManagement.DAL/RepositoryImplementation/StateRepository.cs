using EmployeeManagement.DAL.RepositoryInterfaces;
using EmployeeManagement.DatabaseEntities.Models;

namespace EmployeeManagement.DAL.RepositoryImplementation
{
    internal class StateRepository : IStateRepository
    {
        private readonly employeemanagementContext _dbContext;

        public StateRepository(employeemanagementContext employeemanagementContext)
        {
            _dbContext = employeemanagementContext;
        }

        public async Task<bool> AddStateAsync(State state)
        {
            _dbContext.States.Add(state);
            return await _dbContext.SaveChangesAsync() > 0;
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
