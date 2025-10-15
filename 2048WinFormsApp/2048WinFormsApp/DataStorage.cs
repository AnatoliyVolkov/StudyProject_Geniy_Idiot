using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace _2048WinFormsApp
{
    public static class DataStorage
    {
        private static string resultsFilePath = "results.json";

        public static void Save(User user)
        {
            var allUsers = ReadAll();
            allUsers.Add(user);

            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(allUsers, options);
            File.WriteAllText(resultsFilePath, json);
        }

        public static List<User> ReadAll()
        {
            if (!File.Exists(resultsFilePath))
                return new List<User>();

            try
            {
                var json = File.ReadAllText(resultsFilePath);
                return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            catch
            {
                return new List<User>();
            }
        }
    }
}