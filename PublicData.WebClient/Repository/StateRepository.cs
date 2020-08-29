using PublicData.WebClient.Shared.Entities;
using PublicData.WebClient.Interfaces;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
