using System.Net.Http;
using PublicData.WebClient.Interfaces;
using PublicData.WebClient.Shared.Entities;

namespace PublicData.WebClient.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
