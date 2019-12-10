using System;
using System.Collections.Generic;
using System.Globalization;

namespace ToDoApp
{
    internal class ConsoleUtil
    {
        public ConsoleUtil()
        {
        }
        #region PrintList Method
        //Prints out the list with up to date dataset
        public List<ToDoItem> PrintList(List<ToDoItem> ConsoleList)
        {
            Console.Clear();
            Console.WriteLine("---- My To Do List ----");
            Console.WriteLine("(ID | Description | Status)");
            Console.WriteLine();
            foreach (ToDoItem i in ConsoleList)
            {
                Console.WriteLine($"{i.ID} | {i.Description} | {i.Status}");
            }
            Console.WriteLine();
            return ConsoleList;
        }
        #endregion

        #region GetCommands Method
        //Prints the set of commands for the user to input
        public string GetCommands()
        {
            Console.WriteLine("\nType the command in parenthesis you wish to do.");
            Console.WriteLine("(Add) item  | (Delete) item | (Update) item");
            Console.WriteLine("(Filter) list | (Quit) program");
            string action = Console.ReadLine();
            string UserCmd = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(action);

            return UserCmd;
        }
        #endregion

        #region UpdateSelect Method
        //this prompt is given to user once they initiate an (Update) command
        public string UpdateSelect(int itemID)
        {
            Console.WriteLine("Choose to update Item's Description or Status");
            string select = Console.ReadLine().ToLower();

            return select;
        }
        #endregion

        #region GetDescription Method
        //prompts the user to enter description 
        //the else statement was a way to get around a redundancy that presented itself late in development
        //if they wanted to update an item but only the status then it skips the "update description" process
        public static string GetDescription(bool descUpdate)
        {
            if (descUpdate == true)
            {
                Console.WriteLine("\nEnter in description of task.\n");
            }
            else
            {
                Console.WriteLine("Hit [Enter] to continue.");
            }
            string description = Console.ReadLine();
            return description;
        }
        #endregion

        #region GetStatus Method
        //Prompts user to update the status
        //again, the else statement was to avoid redundancy with 
        //entering in the description if only the status was needing to be updated
        public static string GetStatus(bool statUpdate)
        {
            if (statUpdate == true)
            {
                Console.WriteLine("Enter item's status (Complete | Incomplete):");
            }
            else
            {
                Console.WriteLine("Hit [Enter] to continue.");
            }
            string userInput = Console.ReadLine();
            string status = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userInput);
            return status;
        }
        #endregion

        #region GetItemID Method
        //grabs the ID
        //depending on if user wants to delete or update 
        //method will display specific prompts
        public static int GetItemID(string option)
        {
            if (option.ToLower() == "update")
            {
                Console.WriteLine("\nEnter the ID of the item to update.\n");
            }
            else if (option.ToLower() == "delete")
            {
                Console.WriteLine("\nEnter the ID of the item to delete.\n");
            }
            else
            {
                ConsoleUtil.BadAction();
            }

            string userInput = Console.ReadLine();
            int itemID = int.Parse(userInput);

            return itemID;
        }
        #endregion

        #region GetFilterType Method
        //prompts user to choose how they want to filter the list
        public string GetFilterType(string filterCmd)
        {
            Console.WriteLine("Do you want to filter list by (| All | Complete | Incomplete |): ");
            string filterInput = Console.ReadLine();
            string filterType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(filterInput);
            return filterType;
        }
        #endregion

        #region QuitMessage Method
        //prompts user that they are exiting program 
        //and tells them that the list is being saved
        public static void QuitMessage()
        {
            Console.Clear();
            Console.WriteLine("\nExiting program, saving items...");
            Console.WriteLine("Goodbye!");
        }
        #endregion

        //Below are console outputs for exception handling procedures

        #region BadID Prompt
        //used when invalid ID is given
        public static void BadID()
        {
            Console.WriteLine();
            Console.WriteLine("You entered an invalid ID. Please try again.");
            Console.WriteLine();
        }
        #endregion

        #region BadStatus Prompt
        //used when invalid status is given
        public static void BadStatus()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("You have ented an invalid status. Please try again.");
            Console.WriteLine();
        }
        #endregion

        #region BadFilter Prompt
        //used when invalid filter is given
        public static void BadFilter()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("You have entered an invalid filter type. Please try again.");
            Console.WriteLine();
        }
        #endregion

        #region BadAction Prompt
        //used when a invalid command or action is given
        public static void BadAction()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("You have entered an invalid action. Please try again.");
            Console.WriteLine();
        }
        #endregion

    }
}