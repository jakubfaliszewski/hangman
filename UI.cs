﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class UI
    {

        public static void PrintTitle()
        {
            Console.Clear();
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
        }


        public static void PrintGameMenu(string category, string password, List<char> correctLetters, List<char> wrongLetters, string letterError)
        {
            Console.Clear();
            PrintTitle();
            string usedLetters = string.Join(", ", wrongLetters.ToArray());
            Console.WriteLine("______________________________________");
            Console.WriteLine(letterError ?? "");
            Console.WriteLine("");
            if (category != null)
                Console.WriteLine($"Category: {category}");
            Console.WriteLine($"Password:   {Passwords.GetHiddenPassword(password, correctLetters)}");
            Console.WriteLine($"Wrong used letters: {usedLetters}");
            PrintGameStatus(wrongLetters.Count);
            Console.Write("Pick a letter: ");
        }

        public static bool EndGameUI(bool isWin)
        {
            if (isWin)
            {
                Console.WriteLine("Congrats! You won!");
            }
            else
            {
                Console.WriteLine("Oh, man. So sorry. You lost");
            }
            Console.WriteLine("Do you want to try again? Y/N");
            char userInput = Console.ReadKey().KeyChar;
            if (Char.ToUpper(userInput) == 'Y')
                return true;
            else return false;
        }
        private static void PrintGameStatus(int status)
        {
            // could be simplified
            // but readability here is more important
            switch (status)
            {
                case 0:
                    {
                        Console.WriteLine("  +---+   ");
                        Console.WriteLine("  |      ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("========= ");
                        break;
                    };
                case 1:
                    {
                        Console.WriteLine("  +---+   ");
                        Console.WriteLine("  |   |   ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("========= ");
                        break;
                    };
                case 2:
                    {
                        Console.WriteLine("  +---+   ");
                        Console.WriteLine("  |   |   ");
                        Console.WriteLine("  |   O   ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("========= ");
                        break;
                    };
                case 3:
                    {
                        Console.WriteLine("  +---+   ");
                        Console.WriteLine("  |   |   ");
                        Console.WriteLine("  |   O   ");
                        Console.WriteLine("  |   |   ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("========= ");
                        break;
                    };
                case 4:
                    {
                        Console.WriteLine("  +---+   ");
                        Console.WriteLine("  |   |   ");
                        Console.WriteLine("  |   O   ");
                        Console.WriteLine("  |  /|   ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("========= ");
                        break;
                    };
                case 5:
                    {
                        Console.WriteLine("  +---+   ");
                        Console.WriteLine("  |   |   ");
                        Console.WriteLine("  |   O   ");
                        Console.WriteLine(@"  |  /|\  ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("========= ");
                        break;
                    };
                case 6:
                    {
                        Console.WriteLine("  +---+   ");
                        Console.WriteLine("  |   |   ");
                        Console.WriteLine("  |   O   ");
                        Console.WriteLine(@"  |  /|\  ");
                        Console.WriteLine("  |  /    ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("========= ");
                        break;
                    };
                case 7:
                    {
                        Console.WriteLine("  +---+   ");
                        Console.WriteLine("  |   |   ");
                        Console.WriteLine("  |   O   ");
                        Console.WriteLine(@"  |  /|\  ");
                        Console.WriteLine(@"  |  / \  ");
                        Console.WriteLine("  |       ");
                        Console.WriteLine("========= ");
                        break;
                    };
            }
        }
    }
}
