using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp
{
    class ItemContext : DbContext
    {
        //Database set of ToDoItems, a TABLE of ToDoItems
       public DbSet<ToDoItem> ToDoList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the directory the code is being executed from
            DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

            // get the base directory for the project
            DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

            // add 'students.db' to the project directory
            String DatabaseFile = Path.Combine(ProjectBase.FullName, "todoItems.db");

            // to check what the path of the file is, uncomment the file below
            //Console.WriteLine("using database file :"+DatabaseFile);

            optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
        }
    }
}
