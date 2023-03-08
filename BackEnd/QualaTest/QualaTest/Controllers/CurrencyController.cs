using Microsoft.AspNetCore.Mvc;
using MediatR;
using Services.BranchService.Queries;

namespace QualaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var branches = await Mediator.Send(new GetCurrencyQuery());
            return Ok(GetResponseModel(branches));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdate(SaveOrUpdateCurrencyCommand command)
        {
            var branch = await Mediator.Send(command);
            return Ok(GetResponseModel(branch));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCurrencyCommand command)
        {
            var branch = await Mediator.Send(command);
            return Ok(branch);
        }
    }
}
