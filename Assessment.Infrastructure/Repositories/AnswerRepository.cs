using Assessment.Application.Repositories;
using Assessment.Domain.Answer;
using Microsoft.Extensions.Options;

namespace Assessment.Infrastructure.Repositories;

public class AnswerRepository(IOptions<DataBaseSettings> dataBaseSettings)
    : QDbContext(dataBaseSettings),IAnswerRepository
{
    public async Task<Answer> Create(Answer answer)
    {
        await _answerCollection.InsertOneAsync(answer);
        return answer;
    }

    public async Task<List<Answer>> CreateAnswers(List<Answer> answers)
    {
        await _answerCollection.InsertManyAsync(answers);
        return answers;
    }
}