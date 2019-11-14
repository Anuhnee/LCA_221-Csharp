using System;
using System.Collections.Generic;

namespace ToDoList
{
    internal class ToDoProgram
    {
        private static List<todoItem> ToDoList = new List<todoItem>();

        //todoItem item1 = new todoItem("Set Description Here", "Due/Date/Here", "Priority");
        private static bool quitProgram = false;

        private static void Main(string[] args)
        {
            Console.WriteLine("Press [Enter] to add item\nOtherwise press [Q] to quit");
            string userInput = Console.ReadLine();

            if (userInput == "q")
            {
                quitProgram = true;
                Console.WriteLine("Goodbye!");
            }
            else

                do
                {
                    Console.WriteLine("Please enter in the To Do Action:");
                    string userAction = Console.ReadLine();

                    Console.WriteLine("Enter in due date: ");
                    string userDueDate = Console.ReadLine();

                    Console.WriteLine("Enter in priority level (High, Medium, Low)");
                    string userPriority = Console.ReadLine();

                    todoItem userItem = new todoItem(userAction, userDueDate, userPriority);
                    ToDoList.Add(userItem);

                    Console.WriteLine("Do you wish to enter in another item?");
                    string newItemInput = Console.ReadLine();
                    newItemInput.ToLower();

                    if (userInput == "yes")
                    {
                        break;
                    }
                    else
                    {
                        foreach  (todoItem Item in ToDoList)
                        {
                            Console.WriteLine(userItem);
                        }
                    }

                    Console.ReadLine();
                    quitProgram == true;
                }
                while (quitProgram == false);
        }

        public class todoItem
        {
            public string Description { get; set; }
            public string DueDate { get; set; }
            public string Priority { get; set; }

            public todoItem(string Description, string DueDate, string Priority)
            {
                this.Description = Description;
                this.DueDate = DueDate;
                this.Priority = Priority;
            }

            public string getDesc()
            {
                return Description;
            }

            public string getDate()
            {
                return DueDate;
            }

            public string getPriority()
            {
                return Priority;
            }
        }
    }
}