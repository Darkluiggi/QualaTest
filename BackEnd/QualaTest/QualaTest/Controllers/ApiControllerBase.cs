using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using QualaTest.Controllers.Responses;

namespace QualaTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : Controller
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    public ResponseModel<T> GetResponseModel<T>(T model = null) where T : class
    {
        return new ResponseModel<T>()
        {
            Description = "OK",
            Status = true,
            Result = model
        };
    }
}
