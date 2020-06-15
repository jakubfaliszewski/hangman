using Hangman;
using System;

namespace hangman
{
    class Program
    {
        static void Main()
        {
            UI.PrintTitle();
            UI.PrintMainMenu();
            GetMainMenu();
        }

        static void GetMainMenu()
        {
            switch (Console.ReadKey().Key.ToString())
            {
                case "D1":
                    StandardGame();
                    break;
                case "D2":
                    CustomGame();
                    break;
                case "D3":
                    ExitGame();
                    break;
                default:
                    Console.WriteLine(" - unknown input");
                    Console.WriteLine("Please input valid key");
                    Console.WriteLine("");
                    GetMainMenu();
                    break;
            }
        }

        static void StandardGame()
        {

        }

        static void CustomGame()
        {

        }

        static void ExitGame()
        {
            Environment.Exit(0);
        }
    }
}
