using Assessment.Domain.Question;

namespace Assessment.Domain.Answer;

public class Answer:BaseEntity
{
    public string QuestionId { get; set; } = null!;
    public string QuestionTitle { get; set; } = null!;
    public QuestionHeader Header { get; set; }
    public string Response { get; set; } = null!;
}