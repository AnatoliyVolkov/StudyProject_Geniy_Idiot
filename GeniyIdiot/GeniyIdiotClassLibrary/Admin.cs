namespace GeniyIdiotClassLibrary;

public class Admin
{
    public string Login { get; }
    public string Password { get; }

    public Admin(string name, string password)
    {
        Login = name;
        Password = password;
    }

    public static bool CheckAdmin(string login, string password, string adminFilePath)
    {
        var adminStorage = new AdminStorage(adminFilePath);
        return adminStorage.admins.Any(admin =>
            admin.Login == login.ToLower() && admin.Password == password);
    }

}