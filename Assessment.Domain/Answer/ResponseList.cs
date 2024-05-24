namespace Assessment.Domain.Answer;

public class ResponseList:BaseEntity
{
    public List<Answer> AnswerList { get; set; } = null!;
}