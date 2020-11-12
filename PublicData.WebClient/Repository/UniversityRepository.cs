using PublicData.WebClient.Shared.Entities;
using PublicData.WebClient.Interfaces;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class UniversityRepository : Repository<University>, IUniversityRepository
    {
        public UniversityRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
