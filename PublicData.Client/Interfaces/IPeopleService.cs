using PublicData.Client.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PublicData.Client.Interfaces
{
    public interface IPeopleService
    {
        Task<IEnumerable<People>> Get();
        Task<int> Add(People people);
        Task<People> GetById(int id);
        Task Update(People people);
        Task<HttpResponseMessage> Delete(int id);
    }
}
