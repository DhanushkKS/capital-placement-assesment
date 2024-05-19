using Assessment.Application.Repositories;
using Assessment.Domain.Question;
using MediatR;

namespace Assessment.Application.Queries;

public record GetQuestionByIdQuery(string Id):IRequest<Question>;
public class GetQuestionByIdQueryHandler:IRequestHandler<GetQuestionByIdQuery,Question>
{
    private readonly IQuestionRepository _questionRepository;

    public GetQuestionByIdQueryHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public Task<Question> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        var question = _questionRepository.GetById(request.Id);
        return question;
    }
}