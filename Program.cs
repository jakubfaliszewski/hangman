using Hangman;
using System;
using System.Collections.Generic;

namespace hangman
{
    class Program
    {

        static void Main()
        {
            StartProgram();

        }

        static void StartProgram()
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

        static void StandardGame(dynamic password = null)
        {
            string category = null;
            if (password == null) {
                Password passObject = Passwords.GetOne();
                category = passObject.category;
                var index = new Random().Next(passObject.passwords.Count);
                password = passObject.passwords[index];
            }
            string letterError = null;
            bool gameFinished = false;
            bool isWin = false;
            string validChars = "QWERTYUIOPASDFGHJKLZXCVBNM";
            List<char> wrongLetters = new List<char>();
            List<char> correctLetters = new List<char>();
            do
            {
                UI.PrintGameMenu(category, password, correctLetters, wrongLetters, letterError);
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
                isWin = correctLetters.Count == new HashSet<char>(password.Replace(" ", "")).Count;
                gameFinished = wrongLetters.Count >= 7 || isWin;
            } while (!gameFinished);
            UI.PrintGameMenu(category, password, correctLetters, wrongLetters, letterError);
            EndGame(isWin);
        }

        static void CustomGame(bool isAgain = false)
        {
            string validChars = "QWERTYUIOPASDFGHJKLZXCVBNM ";
            Console.WriteLine("");
            if (!isAgain)
                Console.WriteLine("Please type in your password.");
            string password = Console.ReadLine().ToUpper();
            foreach (char c in password)
            {
                if (!validChars.Contains(c) || password.Length == 0)
                {
                    Console.WriteLine("Password contains invalid character. Try again.");
                    CustomGame(true);
                    return;
                }
            }
            StandardGame(password);
        }

        static void EndGame(bool isWin)
        {
            Console.WriteLine("");
            bool playAgain = UI.EndGameUI(isWin);
            if (playAgain)
            {
                StartProgram();
            }
        }

        static void ExitGame()
        {
            Environment.Exit(0);
        }
    }
}
