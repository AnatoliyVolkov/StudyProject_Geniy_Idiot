namespace GeniyIdiotApp;

public class Questions
{
    public string Question { get; set; }
    public int Answer { get; set; }

    public Questions(string question, int answer)
    {
        Question = question;
        Answer = answer;
    }
}
