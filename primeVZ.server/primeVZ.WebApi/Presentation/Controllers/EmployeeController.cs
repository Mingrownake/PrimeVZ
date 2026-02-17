using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using primeVZ.WebApi.Application.DTO.User;
using primeVZ.WebApi.Application.Services;

namespace primeVZ.WebApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(EmployeeService employeeService): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<EmployeeResponseDto>> GetAll()
        {
            var users = await employeeService.GetAllEmployee();
            if (!users.Any())
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<EmployeeResponseDto>> GetEmployee(Guid id)
        {
            var employee = await employeeService.GetEmployee(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeCreateDto employeeDto)
        {
            await employeeService.AddEmployee(employeeDto);
            return Ok();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await employeeService.DeleteEmployee(id);
            return NoContent();
        }

        // [HttpPut]
        // public async Task UpdateUser([FromBody] EmployeeResponseDto userDto)
        // {
        //     await employeeService.UpdateUser(userDto);
        // }
    }
}
