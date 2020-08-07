using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PublicData.Common.Identity.Models;
using PublicData.Common.Models;
using PublicData.Common.Security.Identity;
using PublicData.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace PublicData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtSettings _jwtSettings;

        public AccountController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;

            // Creating roles
            var roleExists = _roleManager.RoleExistsAsync("User").GetAwaiter().GetResult();
            if (!roleExists)
            {
                _roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();
            }

            roleExists = _roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult();
            if (!roleExists)
            {
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserRegistration userRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = new IdentityUser
            {
                UserName = userRegistration.Email,
                Email = userRegistration.Email,
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(user, userRegistration.Password);
            await _userManager.AddToRoleAsync(user, "Admin");

            await _signInManager.SignInAsync(user, false);

            //var employeeResult = await Mediator.Send(new GetEmployeeByQueryQuery { Employee = new Employee() { Email = userRegistration.Email } });
            var roles = await _userManager.GetRolesAsync(user);

            var registerResult = new AccountResult
            {
                FullName = user.UserName,
                MobileNo = user.PhoneNumber,
                Email = userRegistration.Email,
                Token = await GenerateJwt(userRegistration.Email),
                Roles = roles,
                Successful = true
            };

            return new JsonResult(registerResult);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(userLogin.Email);
                //var employeeResult = await Mediator.Send(new GetEmployeeByQueryQuery { Employee = new Employee() { Email = userLogin.Email } });

                var roles = await _userManager.GetRolesAsync(user);

                var loginResult = new AccountResult();

                //if (employeeResult != null)
                //{
                //    loginResult.EmployeeId = employeeResult.Id;
                //    loginResult.FullName = employeeResult?.Firstname + " " + employeeResult?.Lastname;
                //    loginResult.MobileNo = employeeResult?.Mobile;
                //}
                //else
                //{
                //    loginResult.FullName = user.UserName;
                //    loginResult.MobileNo = user.PhoneNumber;
                //}
                loginResult.Email = userLogin.Email;
                loginResult.Token = await GenerateJwt(userLogin.Email);
                loginResult.Roles = roles;
                loginResult.Successful = true;

                return new JsonResult(loginResult);
            }
            return BadRequest();
        }

        [HttpPost("changepassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePassword changePassword)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return NotFound();

                var result = await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);

                    return BadRequest(result.Errors);
                }
                await _signInManager.RefreshSignInAsync(user);
            }
            return Ok();
        }

        private async Task<string> GenerateJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.ValidAt,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
