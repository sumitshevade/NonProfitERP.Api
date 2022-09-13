using System.Collections.Generic;

namespace NonProfitERP.Common.Models
{
    public class AccountResult
    {
        public Dictionary<string, string> UserInfo { get; set; }
        public string Token { get; set; }
        public IList<string> Roles { get; set; }
        public bool Successful { get; set; }
    }
}
