using static System.Net.Mime.MediaTypeNames;

namespace GeniyIdiotClassLibrary;

public class Question
{
    public string _Question { get; set; }
    public int Answer { get; set; }

    public Question(string question, int answer)
    {
        _Question = question;
        Answer = answer;
    }
    public Question() { }
    
}
