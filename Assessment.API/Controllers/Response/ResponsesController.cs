using Assessment.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.API.Controllers.Response;

public class ResponsesController(IMediator mediator):ApiBaseController
{
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateResponseCommand command)
    {
        var responses =await mediator.Send(command);
        return Ok(responses);
    }
}