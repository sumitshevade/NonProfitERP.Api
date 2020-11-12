using PublicData.WebClient.Interfaces;
using PublicData.WebClient.Shared.Entities;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
