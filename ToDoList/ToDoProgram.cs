using System;
using System.Collections.Generic;

namespace ToDoList
{
    internal class ToDoProgram
    {
        private static List<todoItem> ToDoList = new List<todoItem>();

        //todoItem item1 = new todoItem("Set Description Here", "Due/Date/Here", "Priority");
        private static bool quitProgram = false;

        private static bool continueProgram = true;

        private static void Main(string[] args)
        {
            Console.WriteLine("Press [Enter] to add item\nOtherwise press [Q] to quit");

            string quitInput = Console.ReadLine();
            quitInput.ToLower();

            do
            {
                if (quitInput == "q")
                {
                    quitProgram = true;
                    Console.WriteLine("Goodbye!");
                }
                else if (continueProgram == true)
                {
                    Console.WriteLine("\nPlease enter in the task you need to do:");
                    string userTask = Console.ReadLine();

                    Console.WriteLine("\nEnter in due date: ");
                    string userDueDate = Console.ReadLine();

                    Console.WriteLine("\nEnter in priority level (High, Medium, Low)");
                    string userPriority = Console.ReadLine();

                    todoItem userItem = new todoItem(userTask, userDueDate, userPriority);

                    ToDoList.Add(userItem);

                    Console.WriteLine("\nDo you wish to enter in another item?");
                    string newItemInput = Console.ReadLine();
                    newItemInput.ToLower();

                    if (newItemInput == "yes" || newItemInput == "Yes")
                    {
                        continueProgram = true;
                    }
                    else
                    {
                        foreach (todoItem Item in ToDoList)
                        {
                            Item.printItem();

                        }

                        Console.ReadLine();
                        quitProgram = true;

                    }
                }
            } while (quitProgram == false);
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

            public void printItem()
            {
                Console.WriteLine("\n{0} | {1} | {2}\n", Description, DueDate, Priority);
            }

        }
    }
}