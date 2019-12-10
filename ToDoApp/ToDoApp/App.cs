using System.Collections.Generic;

namespace ToDoApp
{
    internal class App
    {
        private ItemRepository Itemrepo;
        public ConsoleUtil ConsoleUtil;

        public App()
        {
            Itemrepo = new ItemRepository();
            ConsoleUtil = new ConsoleUtil();
        }
        #region DisplayAll Method
        //when filter command is "All"
        //calls the approprate methods from console and repo classes
        //to display all ToDo Items
        private void DisplayAll()
        {
            string filterCmd = "All";

            List<ToDoItem> List = Itemrepo.GetItems(filterCmd);
            ConsoleUtil.PrintList(List);
        }
        #endregion

        #region DisplayFilter Method
        //method that handles filtering
        //calls the filter method from console to prompt filter selection
        //switch statement handles multiple scenarios based on command given
        private void DisplayFilter()
        {
            string filterCmd = "";
            string filter = ConsoleUtil.GetFilterType(filterCmd);

            switch (filter)
            {
                case "Complete":
                    List<ToDoItem> comList = Itemrepo.GetItems(filter);
                    ConsoleUtil.PrintList(comList);
                    break;

                case "Incomplete":
                    List<ToDoItem> incomList = Itemrepo.GetItems(filter);
                    ConsoleUtil.PrintList(incomList);
                    break;

                case "All":
                    List<ToDoItem> allList = Itemrepo.GetItems(filter);
                    ConsoleUtil.PrintList(allList);
                    break;

                default:
                    ConsoleUtil.BadFilter();
                    break;
            }
        }
        #endregion

        #region Start Method
        //main driving method 
        public void Start()
        {
            //calls DisplayAll method as well as the command list
            DisplayAll();
            string command = ConsoleUtil.GetCommands();
            bool quit = false;
            bool update = false;
            string updateSelect = "";
            bool verifyID = true;
            bool verifyStat = true;

            //while the program is not in a "quit" state then run..
            while (!quit)
            {
                //ensures that command given is valid
                CommandValidate(command);
                if (CommandValidate(command) == false)
                {
                    ConsoleUtil.BadAction();
                }

                //switch statement handles command scenarios 
                switch (command)
                {
                    //asks user for description of ToDo Item
                    //once done, the item is generated and added to list
                    case "Add":
                        update = true;
                        string newDesc = ConsoleUtil.GetDescription(update);
                        ItemRepository.AddItem(newDesc);
                        DisplayAll();
                        break;

                    case "Delete":
                        do
                        {
                            // asks user to select ID 
                            //and verifies ID to ensure it's valid
                            int delItemID = ConsoleUtil.GetItemID(command);
                            verifyID = Itemrepo.ItemIDVerify(delItemID);
                            if (verifyID == false)
                            {
                                //if not then call BadID method
                                DisplayAll();
                                ConsoleUtil.BadID();
                            }
                            else
                            {
                                //if valid then call DeleteItem method with given ID 
                                //then display updated list
                                Itemrepo.DeleteItem(delItemID);
                                DisplayAll();
                            }
                          //ensures that this case is looped while the ID is invalid
                        } while (!verifyID);
                        break;

                    case "Update":
                        do
                        {
                            update = true;
                            //user is asked to select an ID to update
                            int itemID = ConsoleUtil.GetItemID(command);
                            //verifies ID is valid 
                            verifyID = Itemrepo.ItemIDVerify(itemID);
                            if (verifyID == false)
                            {
                                //if not call BadID method to prompt user
                                ConsoleUtil.BadID();
                            }
                            else
                            {
                                //if ID is valid, prompts user to select either "description" or "status" to update
                                updateSelect = ConsoleUtil.UpdateSelect(itemID);

                                if (updateSelect == "description")
                                {
                                    //if "description" then automatically set the status update to false
                                    bool statUpdate = false;
                                    //grabs new description
                                    newDesc = ConsoleUtil.GetDescription(update);
                                    //status stays the same
                                    string newStat = ConsoleUtil.GetStatus(statUpdate);
                                    //generates updated ToDo Itm
                                    Itemrepo.UpdateItem(itemID, newDesc, newStat);
                                }
                                else if (updateSelect == "status")
                                {
                                    do
                                    {
                                        //if status is to be updated
                                        //automatically sets "description" update to false 
                                        bool descUpdate = false;
                                        //prompts user for new status and grabs string 
                                        string newStat = ConsoleUtil.GetStatus(update);
                                        //verifies that it is a valid status
                                        verifyStat = StatusValidate(newStat);
                                        if (verifyStat == false)
                                        {
                                            //if not a valid status, prompt user to 
                                            ConsoleUtil.BadStatus();
                                        }
                                        else
                                        {
                                            //if valid then description stays the same
                                            //then generates updated ToDo Item
                                            newDesc = ConsoleUtil.GetDescription(descUpdate);
                                            Itemrepo.UpdateItem(itemID, newDesc, newStat);
                                        }
                                      //while loop ensures that case is looped while an invalid status persists   
                                    } while (verifyStat == false);
                                }
                                //anything other than "description" or "status" will result in invalid action prompt
                                //and set the verifyID to false so the case can get looped again 
                                else
                                {
                                    ConsoleUtil.BadAction();
                                    verifyID = false;
                                }
                            }
                            //while loop ensures Update case is looped while ID is invalid 
                        } while (!verifyID);
                        //Displays list with updated items
                        DisplayAll();
                        break;

                    case "Filter":
                        //runs DisplayFilter method and that method handles everything for this case
                        DisplayFilter();
                        break;

                    case "Quit":
                        //calls the QuitProtocol 
                        //sets quit to be true to exit out of program loop
                        Itemrepo.QuitProtocol();
                        quit = true;
                        break;
                }
                if (quit == true)
                {
                    //then prompts user with exit message
                    ConsoleUtil.QuitMessage();
                }
                else
                {
                    //while still using the program then display commands
                    command = ConsoleUtil.GetCommands();
                }
            }
        }
        #endregion

        //Validation protocols below 

        #region CommandValidate Protocol
        public static bool CommandValidate(string command)
        {
            //ensures that the commands given are valid commands
            bool valid = false;
            if (command.ToLower() == "done" || command.ToLower() == "add" || command.ToLower() == "delete" || command.ToLower() == "update" ||
                command.ToLower() == "filter" || command.ToLower() == "quit")
            {
                valid = true;
            }
            return valid;
        }
        #endregion

        #region StatusValidate Protocol
        public static bool StatusValidate(string status)
        {
            //ensures that the status' given are valid
            bool valid = false;
            if (status.ToLower() == "complete" || status.ToLower() == "incomplete")
            {
                valid = true;
            }
            return valid;
        }
        #endregion

    }
}