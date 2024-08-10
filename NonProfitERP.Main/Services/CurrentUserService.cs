using Microsoft.AspNetCore.Http;
using NonProfitERP.Common.Interfaces;
using System.Security.Claims;

namespace NonProfitERP.Main.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}
