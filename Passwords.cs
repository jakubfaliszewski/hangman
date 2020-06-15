using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class Passwords
    {
        static Random rnd = new Random();

        public static string GetOne()
        {
            int r = rnd.Next(GetList().Count);

            return GetList()[r];
        }

        public static string GetHiddenPassword(string password, List<char> letters)
        {
            string hiddenPass = "";
            foreach (char c in password)
            {
                if(letters.Contains(c))
                {
                    hiddenPass += $"{c} ";
                }
                else if(c == ' ')
                {
                    hiddenPass += "  ";
                } else
                {
                    hiddenPass += "_ ";
                }
            }
            return hiddenPass;
        }

        private static List<string> GetList()
        {
            return new List<string>
            {
                "OMEGA",
                "ALFA",
                "KAPPA"
            };
        }
    }
}
