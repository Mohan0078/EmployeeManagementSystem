using EmployeeManagement.DAL.RepositoryInterfaces;
using EmployeeManagement.DatabaseEntities.Models;

namespace EmployeeManagement.DAL.RepositoryImplementation
{
    public class StateRepository : IStateRepository
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

        public async Task<List<State>> GetAllStates()
        {
           return _dbContext.States.ToList();
        }

        public Task<State> GetStateById(Guid stateId)
        {
            throw new NotImplementedException();
        }
    }
}
