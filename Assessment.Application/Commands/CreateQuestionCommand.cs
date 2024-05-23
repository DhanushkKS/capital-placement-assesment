using Assessment.Application.Dtos;
using Assessment.Application.Repositories;
using Assessment.Domain.Question;
using AutoMapper;
using MediatR;

namespace Assessment.Application.Commands;

public record CreateQuestionCommand(CreateQuestionDto Question): IRequest<Question>;
public class CreateQuestionCommandHandler:IRequestHandler<CreateQuestionCommand,Question>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public CreateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public Task<Question> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var newQuestion = _mapper.Map<Question>(request.Question);
       var question =  _questionRepository.Create(newQuestion);
        return  question;
    }
}