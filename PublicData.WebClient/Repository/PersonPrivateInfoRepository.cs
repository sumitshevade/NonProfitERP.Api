using PublicData.WebClient.Shared.Entities;
using PublicData.WebClient.Interfaces;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class PersonPrivateInfoRepository : Repository<PersonPrivateInformation>, IPersonPrivateInfoRepository
    {
        public PersonPrivateInfoRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
