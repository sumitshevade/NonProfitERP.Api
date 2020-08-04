using System.Collections.Generic;

namespace PublicData.Client.Models
{
    public class AccountResult
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
