using PublicData.WebClient.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PublicData.WebClient.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonModel>> Get();
        Task<int> Add(PersonModel people);
        Task<PersonModel> GetById(int id);
        Task Update(PersonModel people);
        Task<HttpResponseMessage> Delete(int id);
    }
}
