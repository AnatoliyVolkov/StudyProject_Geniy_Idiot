using GeniyIdiotClassLibrary;
using System.Text;

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
        if (!System.IO.File.Exists(_questionPath))
        {
            QuestionsStorage.CreateFirst(_questionPath);
        }

        if (!System.IO.File.Exists(_testPath))
        {
            UserResultStorage.CreateEmptyResultsFile(_testPath);
        }

        var adminPath = Path.Combine(_directoryPath, "admin.json");
        if (!System.IO.File.Exists(adminPath))
        {
            var adminStorage = new AdminStorage(adminPath);
        }
    }
}