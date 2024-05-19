using Assessment.Domain.Question;

namespace Assessment.Application.Dtos;

public class CreateQuestionDto
{
    public string Title { get; set; } = null!;
    public QuestionType QuestionType { get; set; }
    public List<string>? Choices { get; set; }
}