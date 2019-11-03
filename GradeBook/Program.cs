using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        private static void Main(string[] args)
        {
            
            string answer = string.Empty;
            string quitProgram = string.Empty;
            Dictionary<string, string> gradeBook = new Dictionary<string, string>();
            string[] seperator = { " " };

            //Loops through the user input, allowing multiple entries
            do
            {
                //Asks for user input
                Console.WriteLine("\nPlease enter in the student's name\n");
                string studentName = Console.ReadLine();

                Console.WriteLine("\nNow enter in all of the student's grades, seperated by spaces\n");
                string studentGrades = Console.ReadLine();

                //Adds the inputs of string type to gradebook dictionary
                gradeBook.Add(studentName, studentGrades);

                Console.WriteLine("\nPress [Enter] to log another entry, or type [c] to continue");
                answer = Console.ReadLine();

            } while (answer != "c");

            List<int> gradeList = new List<int>();
            List<int> total = new List<int>();

            int totalGrade;
            int avgGrade;
            int n;
            int highGrade;
            int lowGrade;
           
            foreach (KeyValuePair<string, string> entry in gradeBook)
            {
           
                String[] tom = entry.Value.Split(" ");//getting each grade value and putting it in a string array
                lowGrade = Convert.ToInt32(tom.Min());//converting to 32nbit integer and taking the lowest value in tom
                highGrade = Convert.ToInt32(tom.Max());

                n = tom.Length;

                for(int i = 0; i<tom.Length; i++) //this for loop add the converted interger value of tom and adds it to total 'list'
                {
                    total.Add(Convert.ToInt32(tom[i]));
                }

                totalGrade = total.Sum();
                avgGrade = totalGrade / n;
                
                Console.WriteLine("Student: {0}", entry.Key);
                Console.WriteLine("Grades: {0}", entry.Value);
                Console.WriteLine("High: {0} Low: {1} ", highGrade, lowGrade);
                Console.WriteLine("Grade Average: {0}", avgGrade);               

            }

           
            

            




        }
    }
}