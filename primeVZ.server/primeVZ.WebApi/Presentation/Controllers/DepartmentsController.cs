using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using primeVZ.WebApi.Application.DTO.Department;
using primeVZ.WebApi.Application.Services;

namespace primeVZ.WebApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController(DepartmentService departmentService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentResponseDto>>> GetAll()
        {
            var departments = await departmentService.GetAll();
            if (!departments.Any())
            {
                return NotFound();
            }
            return Ok(departments);
        }
    }
}
