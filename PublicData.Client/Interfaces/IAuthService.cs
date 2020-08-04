using PublicData.Client.Models;
using System.Threading.Tasks;

namespace PublicData.Client.Interfaces
{
    public interface IAuthService
    {
        Task<AccountResult> Register(RegisterModel registerModel);
        Task<AccountResult> Login(LoginModel loginModel);
        Task ChangePassword(ChangePasswordModel changePasswordModel);
        Task Logout();
    }
}
