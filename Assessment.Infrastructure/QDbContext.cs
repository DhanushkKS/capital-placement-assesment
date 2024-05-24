using Assessment.Domain.Answer;
using Assessment.Domain.Question;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Assessment.Infrastructure;

public class QDbContext
{
   private protected readonly IMongoCollection<Question> _questionCollection;
   private protected readonly IMongoCollection<Answer> _answerCollection;
   private protected readonly IMongoCollection<ResponseList> _responsesCollection;
   public QDbContext(IOptions<DataBaseSettings> dataBaseSettings)
    {
        var mongoClient = new MongoClient(dataBaseSettings.Value.ConnectionString);
        var mongoDataBase = mongoClient.GetDatabase(dataBaseSettings.Value.DatabaseName);
        _questionCollection = mongoDataBase.GetCollection<Question>(dataBaseSettings.Value.QuestionsCollectionName);
        _answerCollection = mongoDataBase.GetCollection<Answer>(dataBaseSettings.Value.AnswerCollectionName);
        _responsesCollection = mongoDataBase.GetCollection<ResponseList>(dataBaseSettings.Value.ResponsesCollectionName);
    }
}