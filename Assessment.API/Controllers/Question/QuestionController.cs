using Assessment.Application.Commands;
using Assessment.Application.Queries;
using Assessment.Domain.Question;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.API.Controllers.Question;

public class QuestionController(IMediator mediator) : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var questions =await mediator.Send(new GetAllQuestionsQuery());
        return Ok(questions);
    }

    [HttpGet]
    [Route("{id:length(24)}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var question = await mediator.Send(new GetQuestionByIdQuery(id));
        return Ok(question);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateQuestionCommand command)
    {
        var question =await mediator.Send(command);
        return Ok(question);
    }

    [HttpPut]
    [Route("{id:length(24)}")]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateQuestionCommand command)
    {
        if (command.Question.Id != id)
        {
            throw new Exception("Id's doesn't match");
        }
        var question = await mediator.Send(command);
        return Ok(question);
    }

    [HttpDelete]
    [Route("{id:length(24)}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await mediator.Send(new DeleteQuestionCommand(id));
        return Ok();
    }
}