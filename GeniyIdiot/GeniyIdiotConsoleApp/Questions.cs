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

    public static List<Questions> GetQuestions = new List<Questions>()
{
    new Questions("Сколько будет два плюс два умноженное на два?",6),
    new Questions("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",9),
    new Questions("На двух руках 10 пальцев. Сколько пальцев на 5 руках?",25),
    new Questions("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?",60),
    new Questions("Пять свечей горело, три потухли. Сколько свечей осталось?",2)
};

    public static int CheckAnswerUserQuestion(string userName, int questionIndex)
    {
        while (true)
        {
            try
            {
                var userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    throw new Exception($"Вы дали ответ пустой строкой.\n Вам нужно ввести число не длинее 6 знаков.");
                }
                if (short.TryParse(userInput, out var answer))
                {
                    return answer == GetQuestions[questionIndex].Answer ? 1 : 0;
                }
                if (long.TryParse(userInput, out var _))
                {
                    throw new Exception($"{userName}, вы ввели слишком большое число, Вам нужно ввести число не длинее 6 знаков.");
                }
                else
                {
                    throw new Exception($"{userName}, вы ввели букву, Вам нужно ввести число не длинее 6 знаков.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
