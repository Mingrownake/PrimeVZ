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
        public async Task<ActionResult<EmployeeResponseDto>> GetAll([FromQuery] string? term = "")
        {
            var employees = await employeeService.GetAllEmployee(term);
            if (!employees.Any())
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpGet("{id:guid}")]
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
            var employee = await employeeService.GetEmployee(id);
            if (employee is null)
            {
                return NotFound();
            }
            await employeeService.DeleteEmployee(employee.Id);
            return NoContent();
        }

        // [HttpPut]
        // public async Task UpdateUser([FromBody] EmployeeResponseDto userDto)
        // {
        //     await employeeService.UpdateUser(userDto);
        // }
    }
}
