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

        static void StandardGame(string password = null)
        {
            if (password == null)
                password = Passwords.GetOne();
            string letterError = null;
            bool gameFinished = false;
            bool isWin = false;
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
                isWin = correctLetters.Count == (new HashSet<char>(password)).Count;
                gameFinished = wrongLetters.Count >= 7 || isWin; 
            } while (!gameFinished);
            UI.PrintGameMenu(password, correctLetters, wrongLetters, letterError);
            EndGame(isWin);
        }

        static void CustomGame()
        {
            StandardGame("INPUT");
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
