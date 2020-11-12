using PublicData.WebClient.Shared.Entities;
using PublicData.WebClient.Interfaces;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class ProgramRepository : Repository<Shared.Entities.Program>, IProgramRepository
    {
        public ProgramRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
