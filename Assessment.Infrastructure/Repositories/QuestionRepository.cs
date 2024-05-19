using Assessment.Application.Repositories;
using Assessment.Domain.Question;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Assessment.Infrastructure.Repositories;

public class QuestionRepository(IOptions<DataBaseSettings> dataBaseSettings)
    : QDbContext(dataBaseSettings), IQuestionRepository
{
  
    public async Task<List<Question>> GetAll()
    {
        return await _questionCollection.Find(_=>true).ToListAsync();
    }

    public async Task<Question> GetById(string id)
    {
        return await _questionCollection.Find(q => q.Id == id).FirstOrDefaultAsync();
    }

    public async Task Create(Question question)
    {
        await _questionCollection.InsertOneAsync(question);
    }

    public async Task Update(string id, Question question)
    {
         await _questionCollection.ReplaceOneAsync(q=>q.Id==id,question);
    }

    public async Task Delete(string id)
    {
        await _questionCollection.DeleteOneAsync(q => q.Id == id);
    }
}   