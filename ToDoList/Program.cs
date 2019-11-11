using System;

namespace ToDoList
{
    class Program
    {
        todoItem item1 = new todoItem("Set Description Here", "Due/Date/Here", "Priority");
        static string userInput = Console.ReadLine();
        static  bool quitProgram = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Press [Enter] to add item\nOtherwise press [Q] to quit");
            Console.ReadLine();

            if (userInput == "q")
            {
                quitProgram = true;
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Please enter in the To Do Action, along with the due date, and level of priority(High, Medium, Low)");
            }
            


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
