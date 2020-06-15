using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class UI
    {

        public static void PrintTitle()
        {
            Console.WriteLine(@" _                                             ");
            Console.WriteLine(@"| |                                            ");
            Console.WriteLine(@"| |__   __ _ _ __   __ _ _ __ ___   __ _ _ __  ");
            Console.WriteLine(@"| '_ \ / _` | '_ \ / _` | '_ ` _ \ / _` | '_ \ ");
            Console.WriteLine(@"| | | | (_| | | | | (_| | | | | | | (_| | | | |");
            Console.WriteLine(@"|_| |_|\__,_|_| |_|\__, |_| |_| |_|\__,_|_| |_|");
            Console.WriteLine(@"                    __/ |            ");
            Console.WriteLine(@"                   |___/  ");
            Console.WriteLine("");
        }

        public static void PrintMainMenu()
        {
            Console.WriteLine("1. Standard game (random word)");
            Console.WriteLine("2. Custom game (custom word)");
            Console.WriteLine("3. Exit");
            //var userInput = Console.ReadKey().Key.ToString();

            //return userInput;
        }
    }
}
