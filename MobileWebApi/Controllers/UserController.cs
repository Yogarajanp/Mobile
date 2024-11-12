using Microsoft.AspNetCore.Mvc;
using MobileRepository.Base.DTO;
using MobileService.User.Interface;

namespace MobileWebApi.Controllers
{
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is required.");
            }

            var result = await _userService.CreateUser(userDto);


            if (result.Errors.Any())
            {
                return BadRequest(new { Errors = result.Errors });
            }


            return Ok(result.Data);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest("Login data is required.");
            }

            var token = await _userService.AuthenticateAsync(loginDto);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Invalid username or password.");
            }

            // Return only the token
            return Ok(token);
        }
    }
}
