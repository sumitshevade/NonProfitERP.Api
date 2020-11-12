using PublicData.WebClient.Shared.Entities;
using PublicData.WebClient.Interfaces;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class DetailRepository : Repository<Detail>, IDetailRepository
    {
        public DetailRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
