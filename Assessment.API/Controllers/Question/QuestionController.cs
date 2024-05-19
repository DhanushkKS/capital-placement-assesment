using Assessment.Application.Commands;
using Assessment.Application.Queries;
using Assessment.Domain.Question;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.API.Controllers.Question;

public class QuestionController:ApiBaseController
{
    private IMediator _mediator;

    public QuestionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var questions =await _mediator.Send(new GetAllQuestionsQuery());
        return Ok(questions);
    }

    [HttpGet]
    [Route("{id:length(24)}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var question = await _mediator.Send(new GetQuestionByIdQuery(id));
        return Ok(question);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateQuestionCommand command)
    {
        var question =await _mediator.Send(command);
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
        var question = await _mediator.Send(command);
        return Ok(question);
    }

    [HttpDelete]
    [Route("{id:length(24)}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await _mediator.Send(new DeleteQuestionCommand(id));
        return Ok();
    }
}