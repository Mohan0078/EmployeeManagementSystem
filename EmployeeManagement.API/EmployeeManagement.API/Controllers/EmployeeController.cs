using EmployeeManagement.BLL.Interfaces;
using EmployeeManagement.Models.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetEmployeeList")]
        public async Task<IActionResult> GetEmployeeList([FromQuery]string nameFilter)
        {
            try
            {
                var result = await _employeeService.GetEmployeeListAsync(nameFilter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(AddEditEmployeeRequestModel addEditEmployeeRequestModel)
        {
            try
            {
                var result = await _employeeService.AddEmployeeAsync(addEditEmployeeRequestModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteEmployeeById/{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeById(Guid employeeId)
        {
            try
            {
                var result = await _employeeService.DeleteEmployeeByIdAsync(employeeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteSelectedEmployees")]
        public async Task<IActionResult> DeleteSelectedEmployees([FromQuery] List<Guid> employeeIds)
        {
            try
            {
                var result = await _employeeService.DeleteSelectedEmployeesAsync(employeeIds);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
