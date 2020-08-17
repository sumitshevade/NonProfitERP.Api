using PublicData.WebClient.DataModels;
using PublicData.WebClient.Interfaces;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class DepartmentHeadRepository : Repository<DepartmentHead>, IDepartmentHeadRepository
    {
        public DepartmentHeadRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
