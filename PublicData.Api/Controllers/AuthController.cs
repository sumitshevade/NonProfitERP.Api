using System.Threading.Tasks;
using PublicData.Common.Models;
using Microsoft.AspNetCore.Mvc;
using PublicData.Common.Interfaces;
using PublicData.Common.Identity.Models;
using Microsoft.Extensions.Configuration;

namespace PublicData.Api.Controllers
{
    [ApiController]
    public class AuthController : ApiController
    {
        private IUserService _userService;
        private IConfiguration _configuration;
        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        // /api/auth/register
        [HttpPost("register")]
        [ProducesResponseType(200, Type = typeof(UserManagerResponse))]
        [ProducesResponseType(400, Type = typeof(UserManagerResponse))]
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
        [ProducesResponseType(200, Type = typeof(UserManagerResponse))]
        [ProducesResponseType(400, Type = typeof(UserManagerResponse))]
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