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

    public async Task<Question> Create(Question question)
    {
        await _questionCollection.InsertOneAsync(question);
        return question;
    }

    public async Task Update(string id, Question question)
    {
       // var targetQuestion = GetById(id);
       var questionById = GetById(id);
       if ( questionById is null)
       {
           throw new Exception("Question Doesn't Exist");
       }

       if (question.Id!=id)
       {
           throw new Exception("Id doesn't match");
       }
       await _questionCollection.ReplaceOneAsync(q=>q.Id==id,question);
    }

    public async Task Delete(string id)
    {
        var questionById = GetById(id);
        if (questionById is null)
        {
            throw new Exception("Question doesn't exist");
        }
        await _questionCollection.DeleteOneAsync(q => q.Id == id);
    }
}   