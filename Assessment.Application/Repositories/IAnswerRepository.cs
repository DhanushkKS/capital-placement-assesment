using Assessment.Domain.Answer;

namespace Assessment.Application.Repositories;

public interface IAnswerRepository
{
    Task<Answer> Create(Answer answer);
    Task<List<Answer>> CreateAnswers(List<Answer> answers);
}