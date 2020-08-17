using PublicData.WebClient.DataModels;
using PublicData.WebClient.Interfaces;
using System.Net.Http;

namespace PublicData.WebClient.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
