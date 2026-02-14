using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using primeVZ.WebApi.Application.DTO.User;
using primeVZ.WebApi.Application.Services;

namespace primeVZ.WebApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserService userService): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetAll()
        {
            var users = await userService.GetAllUsers();
            if (!users.Any())
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<UserDto>> GetUser(Guid id)
        {
            var user = await userService.GetUser(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task AddUser(UserDto userDto)
        {
            await userService.AddUser(userDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task DeleteUser(Guid id)
        {
            await userService.DeleteUser(id);
        }

        [HttpPut]
        public async Task UpdateUser([FromBody] UserDto userDto)
        {
            await userService.UpdateUser(userDto);
        }
    }
}
