using Assessment.Application.Repositories;
using Assessment.Domain.Answer;
using Microsoft.Extensions.Options;

namespace Assessment.Infrastructure.Repositories;

public class ResponseListRepository(IOptions<DataBaseSettings> dataBaseSettings)
    :QDbContext(dataBaseSettings), IResponseListRepository
{
    public async Task<ResponseList> CreateResponse(ResponseList responseList)
    {
        await _responsesCollection.InsertOneAsync(responseList);
        return responseList;
    }
}