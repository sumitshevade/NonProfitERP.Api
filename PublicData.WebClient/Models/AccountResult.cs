using System;
using System.Collections.Generic;

namespace PublicData.WebClient.Models
{
    public class AccountResult
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public string[] Errors { get; set; }
        public Dictionary<string, string> UserInfo { get; set; }
        public DateTime? ExpireDate { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
