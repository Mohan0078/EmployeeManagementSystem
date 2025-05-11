using EmployeeManagement.BLL.Interfaces;
using EmployeeManagement.DAL.RepositoryInterfaces;
using EmployeeManagement.Models.ResponseModel;

namespace EmployeeManagement.BLL.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<List<StateResponseModel>> GetStateListAsync()
        {
            try
            {
                var allStates = await _stateRepository.GetAllStates();
                return allStates.Select(x => new StateResponseModel
                {
                 StateId = x.StateId,
                 StateName = x.StateName
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
