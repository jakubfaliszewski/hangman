﻿using Hangman;
using HangmanClassLib;
using System;
using System.Collections.Generic;

namespace hangman
{
    class Program
    {
        // instead of required enum
        // dictonary here is more reliable
        private static Dictionary<string, Action> MenuOptions = new Dictionary<string, Action>(){
            {"D1", () => StandardGame()},
            {"D2", () => CustomGame()},
            {"D3", () => Help()},
            {"D4", () => ExitGame()},
        };


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
            string userInput = Console.ReadKey().Key.ToString();
            Action action = null;
            // check if user input is corresponding to viable options from MenuOptions
            bool isValid = MenuOptions.TryGetValue(userInput, out action);
            if (isValid)
                action = MenuOptions[userInput];
            else action = new Action(() =>
            {
                Console.WriteLine(" - unknown input. Please input valid key");
                GetMainMenu();
            });
            action();
        }

        static void StandardGame(dynamic password = null)
        {
            string category = null;
            if (password == null)
            {
                // is password is not given (not custom mode)
                // generate pass from Passwords class
                Password passObject = Passwords.GetOne();
                category = passObject.category;
                var index = new Random().Next(passObject.passwords.Count);
                password = passObject.passwords[index];
            }
            string letterError = null;
            bool isWin;
            bool gameFinished;
            List<char> wrongLetters = new List<char>();
            List<char> correctLetters = new List<char>();
            do
            {
                // print (refresh) game until it's not finished (pass not guessed or still chances available)
                UI.PrintGameMenu(category, password, correctLetters, wrongLetters, letterError);
                letterError = null;
                char newLetter = Char.ToUpper(Console.ReadKey().KeyChar);
                if (correctLetters.Contains(newLetter) || wrongLetters.Contains(newLetter))
                {
                    letterError = "You have already gave this letter!";
                }
                else if (!Passwords.VALID_CHARS.Contains(newLetter))
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
            Console.WriteLine("");
            if (!isAgain)
                Console.WriteLine("Please type in your password.");
            string password = Console.ReadLine().ToUpper();
            foreach (char c in password)
            {
                if (!Passwords.VALID_CHARS.Contains(c) || password.Length == 0)
                {
                    Console.WriteLine("Password contains invalid character. Try again.");
                    CustomGame(true);
                    return;
                }
            }
            StandardGame(password);
        }

        static void Help()
        {
            UI.PrintHelp();
            
            Console.ReadKey();
            StartProgram();
        }


        static void ExitGame()
        {
            Environment.Exit(0);
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
    }
}
