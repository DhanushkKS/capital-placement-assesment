using Assessment.Domain.Question;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Assessment.Infrastructure;

public class QDbContext
{
   private protected readonly IMongoCollection<Question> _questionCollection;

   protected QDbContext(IOptions<DataBaseSettings> dataBaseSettings)
    {
        var mongoClient = new MongoClient(dataBaseSettings.Value.ConnectionString);
        var mongoDataBase = mongoClient.GetDatabase(dataBaseSettings.Value.DatabaseName);
        _questionCollection = mongoDataBase.GetCollection<Question>(dataBaseSettings.Value.QuestionsCollectionName);
    }
}