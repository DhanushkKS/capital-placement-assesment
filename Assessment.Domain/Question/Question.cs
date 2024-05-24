namespace Assessment.Domain.Question;

public class Question:BaseEntity
{
    public QuestionHeader Header { get; set; } = QuestionHeader.PersonalDetails;
    public string Title { get; set; } = null!;
    public QuestionType QuestionType { get; set; }
    public List<string>? Choices { get; set; }
    
}