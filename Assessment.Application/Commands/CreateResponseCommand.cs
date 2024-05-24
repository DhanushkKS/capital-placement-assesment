using Assessment.Application.Dtos;
using Assessment.Application.Repositories;
using Assessment.Domain.Answer;
using AutoMapper;
using MediatR;

namespace Assessment.Application.Commands;

public record CreateResponseCommand(CreateResponseListDto Responses):IRequest<ResponseList>;

public class CreateResponseCommandHandler(IResponseListRepository responseListRepository, IMapper mapper)
    : IRequestHandler<CreateResponseCommand, ResponseList>
{

    public async Task<ResponseList> Handle(CreateResponseCommand request, CancellationToken cancellationToken)
    {
        var responses = mapper.Map<ResponseList>(request.Responses);
        await responseListRepository.CreateResponse(responses);
        return responses;
    }
}