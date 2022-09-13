using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using NonProfitERP.Common.Models;
using NonProfitERP.Common.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using NonProfitERP.Common.Identity.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace NonProfitERP.Common.Security.Identity
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        // TODO: Registration functionality mostly not needed
        public async Task<UserManagerResponse> RegisterUserAsync(UserRegistration model)
        {
            if (model == null)
                throw new NullReferenceException("Invalid data provided.");

            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    Message = "Confirm password doesn't match the password.",
                    IsSuccess = false,
                };

            var identityUser = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if (result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "User created successfully!",
                    IsSuccess = true,
                };
            }

            return new UserManagerResponse
            {
                Message = "User did not create.",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<UserManagerResponse> LoginUserAsync(UserLogin model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "User not found with specified email address.",
                    IsSuccess = false,
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!result)
                return new UserManagerResponse
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var claims = await GetValidClaims(model.Email, user);

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Token = tokenAsString,
                UserInfo = claims.ToDictionary(c => c.Type, c => c.Value),
                Message = "User logged in successfully.",
                IsSuccess = true,
                ExpiryDate = token.ValidTo
            };
        }

        // TODO: Maybe two different methods needed for allowing users to add login... Not sure
        public async Task<UserManagerResponse> CreateRolesAndUsersAsync(UserRegistration model)
        {
            await CreateRoleIfDoesNotExist(model.Role);

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            string password = model.Password;

            var chkUser = await _userManager.CreateAsync(user, password);

            //Add default User to Role Admin
            if (chkUser.Succeeded)
            {
                var result = await _userManager.AddToRoleAsync(user, model.Role);

                return new UserManagerResponse
                {
                    Message = "User created and Role assigned.",
                    IsSuccess = true
                };
            }

            return new UserManagerResponse
            {
                Message = "User did not create.",
                IsSuccess = false,
                Errors = chkUser.Errors.Select(e => e.Description)
            };
        }

        #region -- Helper methods
        private async Task<List<Claim>> GetValidClaims(string email, ApplicationUser user)
        {
            //IdentityOptions _options = new IdentityOptions();

            // TODO: Use actual claim names e.g. for email, firstname (name)

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("Email", email),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName)
            };

            //var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            //claims.AddRange(userClaims);

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }

            return claims;
        }

        private async Task CreateRoleIfDoesNotExist(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var role = new IdentityRole
                {
                    Name = roleName
                };

                await _roleManager.CreateAsync(role);
            }
        }

        public async Task<ApplicationUser> GetUser(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        #endregion
    }
}
