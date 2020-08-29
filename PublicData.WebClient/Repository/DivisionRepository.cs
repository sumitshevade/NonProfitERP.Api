using PublicData.WebClient.Shared.Entities;
using PublicData.WebClient.Interfaces;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class DivisionRepository : Repository<Division>, IDivisionRepository
    {
        public DivisionRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
