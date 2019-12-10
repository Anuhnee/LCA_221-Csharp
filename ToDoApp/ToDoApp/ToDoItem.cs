using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    class ToDoItem
    {
        public int ID { get; private set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public ToDoItem()
        {

        }

        public ToDoItem(string Description)
        {
            this.Description = Description;
            this.Status = "Incomplete";
        }
    }
}
