using PublicData.WebClient.Shared.Entities;
using PublicData.WebClient.Interfaces;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class PersonContactRepository : Repository<PersonContact>, IPersonContactRepository
    {
        public PersonContactRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
