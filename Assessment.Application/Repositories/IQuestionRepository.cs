using Assessment.Domain.Question;

namespace Assessment.Application.Repositories;

public interface IQuestionRepository
{
    Task<List<Question>> GetAll();
    Task<Question> GetById(string id);
    Task Create( Question question);

    Task Update(string id, Question question);
    Task Delete(string id);

}