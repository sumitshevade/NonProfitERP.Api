using PublicData.WebClient.Models;
using System.Threading.Tasks;

namespace PublicData.WebClient.Interfaces
{
    public interface IAuthService
    {
        Task<AccountResult> Register(RegisterModel registerModel);
        Task<AccountResult> Login(LoginModel loginModel);
        Task ChangePassword(ChangePasswordModel changePasswordModel);
        Task Logout();
    }
}
