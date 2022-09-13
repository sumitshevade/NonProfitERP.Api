namespace NonProfitERP.Common.Security.Identity
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Audience { get; set; }
        public int Expiration { get; set; }
        public string Issuer { get; set; }
    }
}