using PublicData.WebClient.Shared.Entities;
using PublicData.WebClient.Interfaces;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class HeaderRepository : Repository<Header>, IHeaderRepository
    {
        public HeaderRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
