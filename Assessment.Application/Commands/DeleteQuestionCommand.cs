using Assessment.Application.Repositories;
using MediatR;

namespace Assessment.Application.Commands;

public record DeleteQuestionCommand(string Id):IRequest<string>, IRequest;
public class DeleteQuestionCommandHandler:IRequestHandler<DeleteQuestionCommand>
{
    private readonly IQuestionRepository _questionRepository;

    public DeleteQuestionCommandHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public Task Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        return _questionRepository.Delete(request.Id);
    }
}