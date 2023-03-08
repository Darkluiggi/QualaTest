using Microsoft.AspNetCore.Mvc;
using MediatR;
using Services.BranchService.Queries;

namespace QualaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ApiControllerBase
    {
        /// <summary>
        /// Get all active branches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var branches = await Mediator.Send(new GetBranchesQuery());
            return Ok(GetResponseModel(branches));
        }

        /// <summary>
        /// Saves or updates a branch
        /// </summary>
        /// <param name="command">Branch info</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SaveOrUpdate(SaveOrUpdateBranchCommand command)
        {
            var branch = await Mediator.Send(command);
            return Ok(GetResponseModel(branch));
        }

        /// <summary>
        /// Delete a branch
        /// </summary>
        /// <param name="command">Branch Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBranchCommand command)
        {
            var branch = await Mediator.Send(command);
            return Ok(branch);
        }
    }
}
