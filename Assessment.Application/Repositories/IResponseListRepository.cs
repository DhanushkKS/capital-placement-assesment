using Assessment.Domain.Answer;

namespace Assessment.Application.Repositories;

public interface IResponseListRepository
{
    Task<ResponseList> CreateResponse(ResponseList responseList);
}