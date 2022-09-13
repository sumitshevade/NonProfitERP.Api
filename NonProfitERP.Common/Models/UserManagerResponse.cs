using System;
using System.Collections.Generic;

namespace NonProfitERP.Common.Models
{
    public class UserManagerResponse
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public Dictionary<string, string> UserInfo { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
