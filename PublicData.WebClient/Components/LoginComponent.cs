using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PublicData.WebClient.Interfaces;
using PublicData.WebClient.Models;
using System;
using System.Threading.Tasks;

namespace PublicData.WebClient.Components
{
    public class LoginComponent : ComponentBase
    {
        [Inject] IAuthService AuthService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILocalStorageService StorageService { get; set; }
        [Inject] public ICommonService CommonService { get; set; }
        [Inject] AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        public LoginModel loginModel = new LoginModel();
        public bool IsBusy { get; set; } = false;
        public AlertMessageType MessageType { get; set; } = AlertMessageType.Success;
        public string Message { get; set; } = string.Empty;

        public async Task LoginUser()
        {
            try
            {
                IsBusy = true;
                var result = await AuthService.LoginUserAsync(loginModel);
                if (result.IsSuccess)
                {
                    var userInfo = new LocalUserInfo()
                    {
                        Id = result.UserInfo[System.Security.Claims.ClaimTypes.NameIdentifier],
                        FirstName = result.UserInfo["FirstName"],
                        LastName = result.UserInfo["LastName"],
                        Email = result.UserInfo["Email"],
                        AccessToken = result.Token,
                        Message = result.Message,
                    };

                    await StorageService.SetItemAsync("User", userInfo);
                    await AuthenticationStateProvider.GetAuthenticationStateAsync();

                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    Message = result.Message;
                    MessageType = AlertMessageType.Error;
                    IsBusy = false;
                }
            }
            catch (Exception)
            {
                IsBusy = false;
            }
        }
    }
}
