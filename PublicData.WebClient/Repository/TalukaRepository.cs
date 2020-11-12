using PublicData.WebClient.Shared.Entities;
using PublicData.WebClient.Interfaces;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class TalukaRepository : Repository<Taluka>, ITalukaRepository
    {
        public TalukaRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
