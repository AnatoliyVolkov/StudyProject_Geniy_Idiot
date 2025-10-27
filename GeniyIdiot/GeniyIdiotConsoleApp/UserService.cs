
using GeniyIdiotClassLibrary;

namespace GeniyIdiotConsoleApp
{
    public class UserService
    {
        public User GetUserInfo()
        {
            Console.WriteLine(Messages.WelcomeTest);
            Console.WriteLine(Messages.EnterLastName);
            string lastName = GetValidUserName();
            Console.WriteLine(Messages.EnterFirstName);
            string name = GetValidUserName();
            Console.WriteLine(Messages.EnterPatronymic);
            string patronymic = GetValidUserName();
            var user = new User($"{name} {lastName} {patronymic}", 0, "");
            User.SafeData(name, lastName, patronymic);
            return user;
        }
        
        public string GetValidUserName()
        {
            while (true)
            {
                var input = Console.ReadLine();
                var result = ValidationHelper.CheckUsernameEntry(input);
                if (result._Success)
                    return result.Value;
                else
                    Console.WriteLine(result.ErrorMessage);
            }
        }

        public bool CheckLogin()
        {
            Console.WriteLine(Messages.Welcome);
            Console.WriteLine(Messages.ChooseRole);
            while (true)
            {
                var input = Console.ReadLine();
                var result = ValidationHelper.CheckUserAnswer(input);

                if (result._Success)
                    return result.Value == "да";
                else
                    Console.WriteLine(result.ErrorMessage);
            }
        }

        public bool GetUserConfirm(string userName)
        {
            while (true)
            {
                var input = Console.ReadLine();
                var result = ValidationHelper.CheckUserAnswer(input);
                if (result._Success)
                    return result.Value == "да";
                else
                    Console.WriteLine(result.ErrorMessage); 
            }
        }
    }
}
