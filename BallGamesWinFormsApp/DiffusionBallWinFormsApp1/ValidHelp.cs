
namespace DiffusionBallWinFormsApp1
{
    public static class ValidHelp
    {
        public static string ValidInput(string text)
        {
            if (text == null || text.Length == 0) { return "Поле не может быть пустым"; }
            if (int.TryParse(text, out int number))
            {
                if (int.Parse(text) < 2) { return "Вы ввели слишком меленькое значение"; }
                if (int.Parse(text) > 100) { return "Вы ввели слишком большое значение"; }
            }
            return "Вы ввели не число"; 
        }
    }
}
