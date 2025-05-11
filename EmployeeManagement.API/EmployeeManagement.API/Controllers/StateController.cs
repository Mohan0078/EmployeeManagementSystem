using EmployeeManagement.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet("GetStateList")]
        public async Task<IActionResult> GetStateList()
        {
            try
            {
              var result = await _stateService.GetStateListAsync();
              return Ok(result);
            }
            catch (Exception ex)
            {
              return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);  
            }
        }
    }
}
