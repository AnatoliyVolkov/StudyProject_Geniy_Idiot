namespace GeniyIdiotApp;

public class Admin
{
    public string Name { get; } 
    public int Password { get; } 

    public Admin(string name, int password) 
    {
        Name = name;
        Password = password;
    }

    public static bool CheckAdmin(string name, int password)
    {
        var adminStorage = new AdminStorage();
        return adminStorage.admins.Any(admin =>
            admin.Name == name && admin.Password == password);
    }

}