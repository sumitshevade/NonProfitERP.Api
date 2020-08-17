using PublicData.WebClient.DataModels;
using PublicData.WebClient.Interfaces;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class SchoolRepository : Repository<School>, ISchoolRepository
    {
        public SchoolRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
