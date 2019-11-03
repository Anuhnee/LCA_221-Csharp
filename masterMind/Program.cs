using System;
using System.Collections.Generic;

namespace masterMind
{
    internal class Program
    {
        private static List<string> colors = new List<string> { "Red", "Yellow", "Blue" };
        private static Random compSelect = new Random();
        private static string UserGuess = Console.ReadLine();

        private static int guessCompare = 0;
        private static bool WinCheck = true;

        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind!\n \nThe computer will randomly choose 2 out of 3 colors.\n \nRed, Yellow, or Blue\n \nPlease enter in your guess: ");
            int colorIndex = compSelect.Next(colors.Count);
            var color1 = colors[colorIndex];
            colorIndex = compSelect.Next(colors.Count);
            var color2 = colors[colorIndex];

            string CPUcolors = color1 + " " + color2;

            //Console.WriteLine("Enter in your guess:");
            guessCompare = string.Compare(UserGuess, CPUcolors, true);

            if (WinCheck == true)
            {
                Console.WriteLine("You win!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Sorry, try again");
                //hints go here, need to figure out how hint logic is to be represented
            }

            do
            {
                Console.WriteLine("Enter in your guess:");
                UserGuess = Console.ReadLine();

                Console.WriteLine(guessCompare);
            }
            while (UserGuess != CPUcolors);

        }
    }
}