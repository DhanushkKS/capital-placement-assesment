using System.Runtime.InteropServices.ComTypes;
using Assessment.Application.Dtos;
using Assessment.Application.Repositories;
using Assessment.Domain.Question;
using AutoMapper;
using MediatR;

namespace Assessment.Application.Commands;

public record UpdateQuestionCommand(string Id, Question Question):IRequest<Question>, IRequest;
public class UpdateQuestionCommandHandler:IRequestHandler<UpdateQuestionCommand>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public UpdateQuestionCommandHandler(IMapper mapper, IQuestionRepository questionRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
    }

    public Task Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var targetQuestion = _questionRepository.GetById(request.Id);
        if (targetQuestion is null)
        {
            throw new Exception("question ille");
        }
        // var updatedQuestion = _mapper.Map<Question>(request.Question);
        var question = _questionRepository.Update(request.Id, request.Question);
        return question;
        
    }
}