using System;
using System.Collections.Generic;

namespace masterMind
{
    class Program
    {
        static List<string> colors = new List<string> { "Red", "Yellow", "Blue" };
        static Random compSelect = new Random();
        static string UserGuess = Console.ReadLine();

        static int guessCompare = 0;
        static bool WinCheck = false;


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind!\n \nThe computer will randomly choose 2 out of 3 colors.\n \nRed, Yellow, or Blue\n \nPlease enter in your guess: ");
            int colorIndex = compSelect.Next(colors.Count);
            var color1 = colors[colorIndex];
            colorIndex = compSelect.Next(colors.Count);
            var color2 = colors[colorIndex];

            string CPUcolors = color1 + " " + color2;

            //Console.WriteLine("Enter in your guess:");


            while (UserGuess != CPUcolors)
            {
                guessCompare = string.Compare(UserGuess, CPUcolors);
                Console.WriteLine("Enter in your guess:");
                UserGuess = Console.ReadLine();


                if (WinCheck == true)
                {
                    Console.WriteLine("You win!");
                    Console.ReadLine();

                }
            }
        }


    }







}
