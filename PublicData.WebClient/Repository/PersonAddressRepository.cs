using PublicData.WebClient.Shared.Entities;
using PublicData.WebClient.Interfaces;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class PersonAddressRepository : Repository<PersonAddress>, IPersonAddressRepository
    {
        public PersonAddressRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
