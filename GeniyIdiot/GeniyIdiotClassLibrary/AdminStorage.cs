using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace GeniyIdiotClassLibrary;

public class AdminStorage
{
    public static string AdminFilePath { get; set; } = "Admin.json";
    public List<Admin> admins = new List<Admin>();
    

    public AdminStorage(string AdminFilePath)
    {
        LoadFromFile();
    }

    public void AddAdmin(string login, int password)
    {
        if (!admins.Any(admin => admin.Login == login.ToLower()))
        {
            admins.Add(new Admin(login.ToLower(), password.ToString()));
            SaveToFile();
        }
    }

    public void RemoveAdmin(string login)
    {
        admins.RemoveAll(admin => admin.Login == login);
        SaveToFile();
    }

    public void SaveToFile()
    {
        try
        {
            var newAdmin = JsonConvert.SerializeObject(admins, Formatting.Indented);
            File.WriteAllText(AdminFilePath, newAdmin);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при сохранении администраторов: {ex.Message}");
        }
    }

    private void LoadFromFile()
    {
        admins.Clear();

        if (!File.Exists(AdminFilePath))
        {
            admins.Add(new Admin("q", "1"));
            SaveToFile();
            return;
        }

        try
        {
            var json = File.ReadAllText(AdminFilePath);
            if (string.IsNullOrEmpty(json))
            {
                admins.Add(new Admin("q", "1"));
                SaveToFile();
                return;
            }
            var adminJson = JsonConvert.DeserializeObject<List<Admin>>(json);
                admins.AddRange(adminJson);
            
        }
        catch (Exception ex) { throw new Exception($"Ошибка при чтении администраторов из JSON: {ex.Message}"); }
    }
}