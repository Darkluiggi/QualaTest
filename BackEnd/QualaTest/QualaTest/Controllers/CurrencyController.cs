using Microsoft.AspNetCore.Mvc;
using MediatR;
using Services.BranchService.Queries;

namespace QualaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ApiControllerBase
    {
        /// <summary>
        /// Get all active currencies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var branches = await Mediator.Send(new GetCurrencyQuery());
            return Ok(GetResponseModel(branches));
        }

        /// <summary>
        /// Saves or updates a branch
        /// </summary>
        /// <param name="command">Currency info</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SaveOrUpdate(SaveOrUpdateCurrencyCommand command)
        {
            var branch = await Mediator.Send(command);
            return Ok(GetResponseModel(branch));
        }

        /// <summary>
        /// Delete a branch
        /// </summary>
        /// <param name="command">Currency Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCurrencyCommand command)
        {
            var branch = await Mediator.Send(command);
            return Ok(branch);
        }
    }
}
