using System.Threading.Tasks;
using PublicData.Common.Models;
using Microsoft.AspNetCore.Mvc;
using PublicData.Common.Interfaces;
using PublicData.Common.Identity.Models;

namespace PublicData.Api.Controllers
{
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // /api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);

                if (result.IsSuccess)
                    return Ok(result); // Status Code: 200 

                return BadRequest(result);
            }

            return BadRequest(new UserManagerResponse
            {
                Message = "Some properties are not valid",
                IsSuccess = false
            }); // Status code: 400
        }

        // /api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]UserLogin model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest(new UserManagerResponse
            {
                Message = "Some properties are not valid",
                IsSuccess = false
            }); // Status code: 400
        }

    }
}