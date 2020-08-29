using PublicData.WebClient.Shared.Entities;
using PublicData.WebClient.Interfaces;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class DivisionHeadRepository : Repository<DivisionHead>, IDivisionHeadRepository
    {
        public DivisionHeadRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
