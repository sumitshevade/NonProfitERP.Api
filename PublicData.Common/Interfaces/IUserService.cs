using PublicData.Common.Identity.Models;
using PublicData.Common.Models;
using System.Threading.Tasks;

namespace PublicData.Common.Interfaces
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(UserRegistration model);

        Task<UserManagerResponse> LoginUserAsync(UserLogin model);

        Task<UserManagerResponse> CreateRolesAndUsersAsync(UserRegistration model);
    }
}
