using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanClassLib
{
    public class Password
    {
        public string category;
        public List<string> passwords;

        public Password(string category, List<string> passwords)
        {
            this.category = category;
            this.passwords = passwords;
        }

    }

    public class Passwords
    {

        static Random rnd = new Random();

        public static Password GetOne()
        {
            int r = rnd.Next(GetList().Count);

            return GetList()[r];
        }

        public static string GetHiddenPassword(string password, List<char> letters)
        {
            string hiddenPass = "";
            foreach (char c in password)
            {
                if (letters.Contains(c))
                {
                    hiddenPass += $"{c} ";
                }
                else if (c == ' ')
                {
                    hiddenPass += "  ";
                }
                else
                {
                    hiddenPass += "_ ";
                }
            }
            return hiddenPass;
        }

        private static List<Password> GetList()
        {
            Password animals = new Password("Animals", new List<string> {
                "CHICKEN", "GIRAFFE", "BUTTERFLY", "PENGUIN", "ELEPHANT", "CROCODILE", "RABBIT"
            });
            Password food = new Password("Food", new List<string> {
                "CHOCOLATE", "BAGUETTE", "SANDWICH", "BROCCOLI", "AVOCADO", "SALT AND PEPPER", "LEMONADE"
            });
            Password home = new Password("Home", new List<string> {
                "DOORMAT", "FIRE EXTINGUISHER", "VACUUM CLEANER", "ALARM CLOCK", "PILLOW", "TRASH CAN", "CURTAINS"
            });
            Password music = new Password("Music", new List<string> {
                "BANJO", "KAZOO", "SAXOPHONE", "KEYBOARD", "TRUMPET", "ABLETON"
            });
            Password sport = new Password("Sport", new List<string> {
                "SOCCER", "TABLE TENNIS", "BADMINTON", "SWIMMING POOL", "CHESS", "SCUBA DIVING", "BOWLING"
            });
            Password computer = new Password("Computer", new List<string> {
                "MICROPHONE", "CALCULATOR", "CONTROLLER", "SPEAKERS", "RAM BONES", "HDMI CABLE", "GAMING SET"
            });

            return new List<Password>() { animals, food, home, music, sport, computer };

        }
    }
}
