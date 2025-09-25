namespace GeniyIdiotApp;

public static class AdminWork
{
    public static bool TryLoginAdmin(int attempts = 3)
    {
        int count = 0;
        while (count < attempts)
        {
            try
            {
                Console.WriteLine("Вы продолжаете как администратор.");
                Console.WriteLine("Введите логин:");
                var login = Console.ReadLine();
                Console.WriteLine("Введите пароль:");
                var password = int.Parse(Console.ReadLine());

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
        Console.WriteLine("Превышено максимальное количество попыток. Возврат в главное меню.");
        return false;
    }
              
    public static void AdminMenu(string questionPath)
    {
        while (true)
        {
            Console.WriteLine("РЕЖИМ АДМИНИСТРАТОРА");
            Console.WriteLine("1. Просмотреть вопросы");
            Console.WriteLine("2. Добавить вопрос");
            Console.WriteLine("3. Удалить вопрос");
            Console.WriteLine("4. Просмотреть результаты");
            Console.WriteLine("5. Выйти");
            Console.Write("Выберите действие (1-5): ");

            switch (Console.ReadLine())
            {
                case "1": FileProvider.Show(questionPath); break;
                case "2": QuestionsStorage.AddQuestion(questionPath); break;
                case "3": QuestionsStorage.DeleteQuestion(questionPath); break;
                case "4": FileProvider.Show("test_results"); break;
                case "5": Console.WriteLine("Выход из режима администратора."); return;
                default: Console.WriteLine("Неверный выбор!"); break;
            }

            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }
    }
}