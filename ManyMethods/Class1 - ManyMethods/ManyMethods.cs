using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class1___ManyMethods
{
    class ManyMethods
    {
        static void Main()
        {
            hello();
            addition();
            catDog();
            Oddevent();
            inches();
            echo();
            killgrams();
            date();
            age();
            guess();
        }

        static void hello()
        {
            //Hello Method//
            string userName;
            Console.Write("Hello! What is your name? ");
            userName = (Console.ReadLine());
            Console.WriteLine("Okay, {0} lets have you do some mindless tasks!", userName);

            Console.WriteLine("Please hit 'Enter' to progress to next task.");
            Console.ReadKey();
            
        }

        static void addition()
        {
            int Value1 = 0;
            int Value2 = 0;
            int Total = 0;
            Console.Write("Enter a number: ");
            Value1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter another number: ");
            Value2 = Convert.ToInt32(Console.ReadLine());
            Total = (Value1 + Value2);
            Console.Write("The total of {0} and {1} = {2}", Value1, Value2, Total);
            _ = Console.ReadLine();

        }

        static void catDog()
        {
            string favAnimal = null;

            Console.WriteLine("Do you prefer cats or dogs? ");
            favAnimal = Console.ReadLine();

            if (favAnimal == "Cats" || favAnimal == "cats")
            {
                Console.WriteLine("Meow!");
            }

            else if (favAnimal == "Dogs" || favAnimal == "dogs")
            {
                Console.WriteLine("Woof!");
            }

            else
            {
                Console.WriteLine("Please enter either Cats or Dogs");
                _ = Console.ReadLine();
            }
        }

        static void Oddevent()
        {
            Console.WriteLine("Please type a random number: ");
            int userNumber = Convert.ToInt32(Console.ReadLine());


            if (userNumber % 2 == 0)
            {
                Console.WriteLine("Your number is even.");
            }

            else if (userNumber % 2 != 0)
            {
                Console.WriteLine("Your number is odd");
            }


        }

        static void inches()
        {
            double inch;

            Console.WriteLine("Please enter your height in Feet: ");
            double feet = Convert.ToDouble(Console.ReadLine());
            inch = feet * 12;

            Console.WriteLine("You are {0} inches tall!", inch);
        }

        static void echo()
        {
            Console.WriteLine("Please type a word to witness an echo: ");
            string input = Console.ReadLine();
            string upper = input.ToUpper();
            string lower = input.ToLower();

            Console.WriteLine(upper + " " + lower + " " + lower);
        }

        static void killgrams()
        {
            double kilograms;

            Console.WriteLine("Please enter your weight in pounds: ");
            double pounds = Convert.ToDouble(Console.ReadLine());

            kilograms = pounds / 2.205;

            Console.WriteLine("You weigh {0} in KIlograms!", kilograms);
        }

        static void date()
        {
            Console.WriteLine("The current date and time is: ");

            var today = DateTime.Now;
            Console.WriteLine(today);
        }

        static void age()
        {
            Console.WriteLine("Please type out your birth year: ");
            var input = Convert.ToString(Console.ReadLine());

            DateTime currentYear = DateTime.Today;

            int age = currentYear.Year - Convert.ToInt32(input);
            Console.WriteLine("You are {0} years young!", age);
        }

        static void guess()
        {
            Console.WriteLine("Type the magic word to win!");
            string answer = Console.ReadLine();

            if (answer == "Csharp")
            {
                Console.WriteLine("YOU WIN! :D");
            }

            else
            {
                Console.WriteLine("OOF! Sorry that is not the magic word :(");
            }
        }
    }
}
