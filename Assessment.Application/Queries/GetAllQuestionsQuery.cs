using Assessment.Application.Repositories;
using Assessment.Domain.Question;
using MediatR;

namespace Assessment.Application.Queries;

public record GetAllQuestionsQuery():IRequest<List<Question>>;
public class GetAllQuestionQueryHandler:IRequestHandler<GetAllQuestionsQuery,List<Question>>
{
    private readonly IQuestionRepository _questionRepository;

    public GetAllQuestionQueryHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public Task<List<Question>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = _questionRepository.GetAll();
        return questions;
    }
}