using System.Collections.Generic;
using System.Linq;

namespace ToDoApp
{
    internal class ItemRepository
    {
        //instantiate instance of context
        public static ItemContext context = new ItemContext();

        public ItemRepository()
        {
            //when ItemRepository is instantiated
            //makes sure context table exists
            //if not, creates a new table
            context.Database.EnsureCreated();
        }

        #region AddItems Method
        public static void AddItem(string description)
        {
            //creates new instance of ToDoItem class
            //adds new instance to the context(table)
            ToDoItem todoItem = new ToDoItem(description);
            context.Add(todoItem);

            //saves the context
            context.SaveChanges();
        }
        #endregion

        #region DeleteItem Method
        public void DeleteItem(int ItemID)
        {
            //LINQ handles finding entry by matching ID given from user and what's in the dataset
            //Removes the item selected from dataset
            //saves the changes to the dataset
            ToDoItem DeleteItem = context.ToDoList.Where(x => x.ID == ItemID).FirstOrDefault();
            context.Remove(DeleteItem);
            context.SaveChanges();
        }
        #endregion

        #region UpdateItem Method
        public void UpdateItem(int itemID, string description, string status)
        {
            //LINQ to find ID given from user
            ToDoItem UpdatedToDoItem = context.ToDoList.Where(x => x.ID == itemID).FirstOrDefault();

            //if the string given is NOT empty then update the description
            if (description != "")
            {
                UpdatedToDoItem.Description = description;
            }
            //if string given is NOT empty then update status
            if (status != "")
            {
                UpdatedToDoItem.Status = status;
            }
            //update the dataset and save changes made
            context.Update(UpdatedToDoItem);
            context.SaveChanges();
        }
        #endregion

        #region GetItems Method
        //depending on filter type given from user
        //it will display the list based on user input
        public List<ToDoItem> GetItems(string filterCmd)
        {
            List<ToDoItem> LowLvlList = new List<ToDoItem>().ToList();
            if (filterCmd == "All")
            {
                LowLvlList = context.ToDoList.ToList();
            }
            else
            {
                if (filterCmd == "Complete")
                {
                    LowLvlList = context.ToDoList.Where(x => x.Status == filterCmd).ToList();
                }
                else if (filterCmd == "Incomplete")
                {
                    LowLvlList = context.ToDoList.Where(x => x.Status == filterCmd).ToList();
                }
            }
            return LowLvlList;
        }
        #endregion

        public bool ItemIDVerify(int itemID)
        {
            bool verifyID = context.ToDoList.Any(x => x.ID == itemID);
            return verifyID;
        }

        public void QuitProtocol()
        {
            context.SaveChanges();
        }
    }
}