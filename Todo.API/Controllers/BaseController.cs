using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.BLL.MediatR.ResultVariations;

namespace Todo.API.Controllers;

[ApiController]
[Route("server/[controller]")]
public class BaseController : ControllerBase
{
    private IMediator? _mediator;

    public BaseController()
    {
    }

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>() 
                                                  ?? throw new InvalidOperationException("IMediator service not found.");

    protected ActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            if (result is NullResult<T>)
            {
                return Ok(result.Value);
            }

            return (result.Value is null) ?

                NotFound("Not Found") : Ok(result.Value);
        }

        return BadRequest(result.Reasons);
    }
}