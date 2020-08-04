
using System.Collections.Generic;
using System.Security.Claims;

namespace PublicData.Common.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
