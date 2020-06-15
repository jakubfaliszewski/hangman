using Hangman;
using System;
using System.Collections.Generic;

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
                    Console.WriteLine(" - unknown input. Please input valid key");
                    GetMainMenu();
                    break;
            }
        }

        static void StandardGame(string password = null)
        {
            if (password == null)
                password = Passwords.GetOne();
            string letterError = null;
            string validChars = "QWERTYUIOPASDFGHJKLZXCVBNM";
            List<char> wrongLetters = new List<char>();
            List<char> correctLetters = new List<char>();
            do
            {
                UI.PrintGameMenu(password, correctLetters, wrongLetters, letterError);
                letterError = null;
                char newLetter = Char.ToUpper(Console.ReadKey().KeyChar);
                if (correctLetters.Contains(newLetter) || wrongLetters.Contains(newLetter))
                {
                    letterError = "You have already gave this letter!";
                }
                else if (!validChars.Contains(newLetter))
                {
                    letterError = "Invalid character!";
                }
                else
                {
                    if (password.Contains(newLetter))
                        correctLetters.Add(newLetter);
                    else
                        wrongLetters.Add(newLetter);
                }
            } while (wrongLetters.Count < 8);

        }

        static void CustomGame()
        {
            StandardGame("INPUT");
        }

        static void ExitGame()
        {
            Environment.Exit(0);
        }
    }
}
