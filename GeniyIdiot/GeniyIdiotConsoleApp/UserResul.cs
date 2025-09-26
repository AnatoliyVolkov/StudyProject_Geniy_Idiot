namespace GeniyIdiotApp;

public class UserResul
{
    public string FIO { get; set; }
    public int Answer { get; set; }
    public string Diagnostic { get; set; }

    public UserResul(string fio, int answer, string diagnostic)
    {
        FIO = fio;
        Answer = answer;
        Diagnostic = diagnostic;
    }
}
