namespace GeniyIdiotApp;

public static class AdminService
{
    public static bool TryLogin(int attempts = 3)
    {
        int count = 0;
        while (count < attempts)
        {
            try
            {
                Console.WriteLine("Вы продолжаете как администратор.");
                Console.WriteLine("Введите логин:");
                var login = ValidationHelper.CheckUsernameEntry(Console.ReadLine());
                Console.WriteLine("Введите пароль:");
                var password = ValidationHelper.CheckAdminInput();

                if (Admin.CheckAdmin(login, password))
                {
                    Console.WriteLine("Авторизация успешна!");
                    return true;
                }
                else
                {
                    count++;
                    Console.WriteLine($"НЕВЕРНО! У вас осталось {attempts - count} попыток.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        Console.WriteLine("Превышено максимальное количество попыток. \n За вами выехал наряд ФСБ, собирайте вещи. \n Пока он едет пройдите наш тест.");
        ValidationHelper.CheckLogin();
        return false;
    }
              
    public static void Menu(string questionPath)
    {
        while (true)
        {
            Console.WriteLine("РЕЖИМ АДМИНИСТРАТОРА");
            Console.WriteLine("1. Просмотреть вопросы");
            Console.WriteLine("2. Добавить вопрос");
            Console.WriteLine("3. Удалить вопрос");
            Console.WriteLine("4. Просмотреть результаты");
            Console.WriteLine("5. Выйти из программы");
            Console.WriteLine("6. Выйти в главное меню");
            Console.Write("Выберите действие (1-6): ");

            switch (Console.ReadLine())
            {
                case "1": FileProvider.Show(questionPath); break;
                case "2": QuestionsStorage.Add(questionPath); break;
                case "3": QuestionsStorage.Delete(questionPath); break;
                case "4": FileProvider.Show("test_results"); break;
                case "5": Console.WriteLine("Выход из режима администратора."); return;
                case "6": ValidationHelper.CheckLogin(); return;
                default: Console.WriteLine("Неверный выбор!"); break;
            }

            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }
    }
}