using GeniyIdiotClassLibrary;

namespace GeniyIdiotConsoleApp;

public class File
{
    private readonly string _directoryPath;
    private readonly string _questionPath;
    private readonly string _testPath;

    public File(string directoryPath, string questionPath, string testPath)
    {
        _directoryPath = directoryPath;
        _questionPath = questionPath;
        _testPath = testPath;
    }

    public void CheckFiles()
    {
        Directory.CreateDirectory(_directoryPath);

        var testHeader = string.Format("|| {0,-35} || {1,-25} || {2,-15} ||", "ФИО", "Набранные баллы", "Диагноз");
        var questionHeader = string.Format("{0,-5} || {1,-85} || {2,-15}", "П/П", "Вопрос", "Ответ");

        FileProvider.Create(_testPath, testHeader);
        FileProvider.Create(_questionPath, questionHeader);
        QuestionsStorage.CreateFirst(_questionPath);
    }
}