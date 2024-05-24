using System.Runtime.InteropServices.ComTypes;
using Assessment.Application.Dtos;
using Assessment.Application.Repositories;
using Assessment.Domain.Question;
using AutoMapper;
using MediatR;

namespace Assessment.Application.Commands;

public record UpdateQuestionCommand(Question Question):IRequest<Question>;
public class UpdateQuestionCommandHandler:IRequestHandler<UpdateQuestionCommand,Question>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public UpdateQuestionCommandHandler(IMapper mapper, IQuestionRepository questionRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
    }

    public Task<Question> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = _questionRepository.Update(request.Question.Id, request.Question);
        return (Task<Question>)question;
        
    }
}