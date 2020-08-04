using System.Collections;
using System.Collections.Generic;

namespace PublicData.Common.Models
{
    public class AccountResult
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Token { get; set; }
        public IList<string> Roles { get; set; }
        public bool Successful { get; set; }
    }
}
