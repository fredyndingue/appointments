using App.Services.Auth;
using Appointments.App.Services;
using Appointments.Domain.Entities;
using Appointments.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        { 
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignInModel user)
        {
            // Error checks

            if (String.IsNullOrEmpty(user.Email))
            {
                return BadRequest(new { message = "User email needs to entered" });
            }
            else if (String.IsNullOrEmpty(user.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            // Try login

            var loggedInUser = await _userService.SignIn(
                new User{ Email = user.Email, Password = user.Password}
                );

            // Return responses

            if (loggedInUser != null)
            {
                return Ok(loggedInUser);
            }

            return BadRequest(new { message = "User login unsuccessful" });
        }
    }
}
