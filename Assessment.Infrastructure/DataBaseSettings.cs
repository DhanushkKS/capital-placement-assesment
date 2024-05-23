namespace Assessment.Infrastructure;

public class DataBaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string QuestionsCollectionName { get; set; } = null!;

    public string AnswerCollectionName { get; set; } = null!;
}