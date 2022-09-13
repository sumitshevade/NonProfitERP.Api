using NonProfitERP.Common.Identity.Models;
using NonProfitERP.Common.Models;
using NonProfitERP.Common.Security.Identity;
using System.Threading.Tasks;

namespace NonProfitERP.Common.Interfaces
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(UserRegistration model);

        Task<UserManagerResponse> LoginUserAsync(UserLogin model);

        Task<UserManagerResponse> CreateRolesAndUsersAsync(UserRegistration model);

        Task<ApplicationUser> GetUser(string id);
    }
}
