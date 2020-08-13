using PublicData.WebClient.Models;
using System.Threading.Tasks;

namespace PublicData.WebClient.Interfaces
{
    public interface IAuthService
    {
        Task<AccountResult> RegisterUserAsync(RegisterModel request);
        Task<AccountResult> LoginUserAsync(LoginModel request);

        //Task ChangePassword(ChangePasswordModel changePasswordModel);
    }
}
