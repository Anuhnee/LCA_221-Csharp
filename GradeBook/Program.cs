﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string answer = string.Empty;
            string quitProgram = string.Empty;
            Dictionary<string, string> gradeBook = new Dictionary<string, string>();
            string[] seperator = { " " };

            do
            {
                Console.WriteLine("\nPlease enter in the student's name\n");
                string studentName = Console.ReadLine();

                Console.WriteLine("\nNow enter in all of the student's grades, seperated by spaces\n");
                string studentGrades = Console.ReadLine();

                gradeBook.Add(studentName, studentGrades);

                Console.WriteLine("\nPress [Enter] to log another entry, or type [c] to continue");
                answer = Console.ReadLine();
            } while (answer != "c");

            foreach (KeyValuePair<string,string> entry in gradeBook)
            {

                Console.WriteLine("Student: {0}, Grades: {1}", entry.Key, entry.Value);


                var name = gradeBook.Keys;
                var grade = gradeBook.Values;

               

            }

            


        }
    }
}