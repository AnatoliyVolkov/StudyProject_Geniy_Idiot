using Newtonsoft.Json;

namespace GeniyIdiotClassLibrary;

public class Admin
{

    public string Login { get; } 

    public string Password { get; } 

    public Admin(string login, string password)
    {
        Login = login;
        Password = password;
    }

   
    
    public static bool CheckAdmin(string login, string password, string adminFilePath)
    {
        if (!File.Exists(adminFilePath))
        {
            var adminStorage = new AdminStorage(adminFilePath);
            return adminStorage.admins.Any(admin =>
        admin.Login.Equals(login, StringComparison.OrdinalIgnoreCase) &&
        admin.Password == password);
        }
        var json = File.ReadAllText(adminFilePath);
        var admins = JsonConvert.DeserializeObject<List<Admin>>(json);
        return admins.Any(admin =>
            admin.Login.Equals(login, StringComparison.OrdinalIgnoreCase) &&
            admin.Password == password);
    }


}