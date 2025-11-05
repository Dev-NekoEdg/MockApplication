using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockApplication.Application.Users;
using MockApplication.Domain.Models;

namespace MockApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserModel model)
        {
            var result = await service.CreateUserAsync(model);
            return Ok(result);
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserModel model)
        {
            model.UserId = id;
            var result = await service.CreateUserAsync(model);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await service.GetUsersAsync();
            return Ok(result);
        }


        [HttpGet("/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            var result = await service.GetUserByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteUserByIdAsync(string id)
        {
            var result = await service.DeleteUserAsync(id);
            return Ok(result);
        }

    }
}
