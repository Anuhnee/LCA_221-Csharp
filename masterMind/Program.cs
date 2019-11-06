using System;
using System.Collections.Generic;
using System.Linq;

namespace masterMind
{
    internal class MasterMind
    {
        private static List<string> colors = new List<string> { "Red", "Yellow", "Blue" };
        private static Random CPUselect = new Random();

        private static bool WinCheck = false;

        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind!\n \nThe computer will randomly choose 2 out of 3 colors.\n \nRed, Yellow, or Blue\n\nIt is up to YOU to figure out what the computer chose!\n\nPlease enter in your guess: ");
            int colorIndex = CPUselect.Next(colors.Count);
            var color1 = colors[colorIndex];
            colorIndex = CPUselect.Next(colors.Count);
            var color2 = colors[colorIndex];

            string[] CPUcolors = { color1, color2 };
            string[] UserGuess = Console.ReadLine().Split(" ");

            while (!WinCheck)
            {
                UserGuess.SequenceEqual(CPUcolors, StringComparer.CurrentCultureIgnoreCase);
                if (UserGuess.Contains("red") || UserGuess.Contains("yellow") || UserGuess.Contains("blue") || UserGuess.Length < 0)
                {
                    Console.WriteLine("\nPlease be sure you are using proper casing and be sure to check spelling.\nYou must enter in 2 colors, seperated by spaces, from the list\nPlease try again.\n");
                    UserGuess = Console.ReadLine().Split(" ");
                }
                else if (UserGuess[0] != CPUcolors[0] && UserGuess[1] != CPUcolors[1] && UserGuess[0] != CPUcolors[1] && UserGuess[1] != CPUcolors[0])
                {
                    Console.WriteLine("\nYour hint: 0-0\n \nTry again");
                    UserGuess = Console.ReadLine().Split(" ");
                }
                else if (UserGuess[0] == CPUcolors[1] && UserGuess[1] != CPUcolors[0])
                {
                    Console.WriteLine("\nYour hint: 1-0\n \nTry again");
                    UserGuess = Console.ReadLine().Split(" ");
                }
                else if (UserGuess[0] == CPUcolors[0] && UserGuess[1] != CPUcolors[1] || UserGuess[1] == CPUcolors[1] && UserGuess[0] != CPUcolors[0])
                {
                    Console.WriteLine("\nYour hint: 0-1\n \nTry again");
                    UserGuess = Console.ReadLine().Split(" ");
                }
                else if (UserGuess[0] == CPUcolors[1] && UserGuess[1] == CPUcolors[0])
                {
                    Console.WriteLine("\nYour hint: 2-0\n \nTry again");
                    UserGuess = Console.ReadLine().Split(" ");
                }
                else
                {
                    WinCheck = true;
                    Console.WriteLine("\nYou Win! Time to eat some cake!");
                    Console.ReadLine();
                }
            }
        }
    }
}