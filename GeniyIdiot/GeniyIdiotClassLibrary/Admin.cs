namespace GeniyIdiotClassLibrary;

public class Admin
{
    public string Login { get; }
    public int Password { get; }

    public Admin(string name, int password)
    {
        Login = name;
        Password = password;
    }

    public static bool CheckAdmin(string login, int password)
    {
        var adminStorage = new AdminStorage();
        return adminStorage.admins.Any(admin =>
            admin.Login == login.ToLower() && admin.Password == password);
    }

}