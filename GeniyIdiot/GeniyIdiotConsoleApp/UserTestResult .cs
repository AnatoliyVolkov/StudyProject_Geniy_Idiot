namespace GeniyIdiotApp;

public class UserTestResult
{
    public string FIO { get; set; }
    public int Answer { get; set; }
    public string Diagnostic { get; set; }

    public UserTestResult(string fio, int answer, string diagnostic)
    {
        FIO = fio;
        Answer = answer;
        Diagnostic = diagnostic;
    }
}
