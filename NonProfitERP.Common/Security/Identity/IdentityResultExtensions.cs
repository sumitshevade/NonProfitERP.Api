using Microsoft.AspNetCore.Identity;
using NonProfitERP.Common.Models;
using System.Linq;

namespace NonProfitERP.Common.Security.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}
