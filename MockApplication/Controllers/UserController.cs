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

        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok("UserController is working!");
        }

    }
}
