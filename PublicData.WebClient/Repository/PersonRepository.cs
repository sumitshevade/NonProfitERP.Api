using PublicData.WebClient.DataModels;
using PublicData.WebClient.Interfaces;
using PublicData.WebClient.Services;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
