using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NonProfitERP.Application.Features.Custom;
using NonProfitERP.Main.Controllers;

namespace NonProfitERP.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class CustomController : ApiController
    {
        [HttpPost("getAllByEntities")]
        public async Task<IActionResult> PostBatch(string entities)
        {
            var result = await Mediator.Send(new GetPageDataByEntitiesQuery { Entities = entities });
            
            return new JsonResult(result);
        }
    }
}
