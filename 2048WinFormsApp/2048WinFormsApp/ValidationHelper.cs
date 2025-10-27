
using Microsoft.VisualBasic.Logging;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _2048WinFormsApp;

public class ValidationHelper
{
    static public char[] InvalidChars =
    {
        '!', '@', '#', '$', '%', '^', '&', '*', '(', ')',
        '_', '+', '=', '{', '}', '[', ']', '|', '\\', ':',
        ';', '"', '\'', '<', '>', ',', '.', '?', '/', '№',
    };

    public static string CheckUsernameEntry(string name)
    {
        try
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Нельзя оставлять поле пустым");

            if (short.TryParse(name, out _))
                throw new Exception("Нельзя вводить числа в поле имя");

            if (name.Contains(" "))
                throw new Exception("Имя не может содержать пробелы");

            if (name.Any(c => InvalidChars.Contains(c)))
                throw new Exception("Имя не может содержать символы, кроме букв.");

            string formattedName = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            return formattedName;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return string.Empty;
        }
    }

    public static string CheckMapSize(string size)
    {
        try
        {
            if (string.IsNullOrEmpty(size))
                throw new Exception("Нельзя оставлять поле пустым");
            if (size.Contains(" "))
                throw new Exception("Имя не может содержать пробелы");
            if (size.Any(c => InvalidChars.Contains(c)))
                throw new Exception("Имя не может содержать символы, кроме букв.");
            if (int.Parse(size) > 10 || int.Parse(size) < 4)
                throw new Exception("Число должно быть в диапазоне от 4 до 10");
            return size;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return string.Empty;
        }
    }
}
