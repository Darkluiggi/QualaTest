using Microsoft.AspNetCore.Mvc;
using MediatR;
using Services.BranchService.Queries;

namespace QualaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var branches = await Mediator.Send(new GetBranchesQuery());
            return Ok(GetResponseModel(branches));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdate(SaveOrUpdateBranchCommand command)
        {
            var branch = await Mediator.Send(command);
            return Ok(GetResponseModel(branch));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBranchCommand command)
        {
            var branch = await Mediator.Send(command);
            return Ok(branch);
        }
    }
}
