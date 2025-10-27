using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048WinFormsApp
{
    public class User
    {
        public string UserName { get; set; }
        public int Score { get; set; }

        public User(string userName, int score)
        {
            UserName = userName;
            Score = score;
        }
    }
}