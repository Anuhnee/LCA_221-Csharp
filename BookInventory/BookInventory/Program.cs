using System;

namespace BookInventory
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //instantiate an instance of the context first
            BookContext context = new BookContext();

            //Ensures table exists,
            //creates one if it doesn't exist
            context.Database.EnsureCreated();

            Console.WriteLine("Enter in book title and author separated by a comma, to add to database.");
            Console.WriteLine("Example: \"Lord of The Rings, J.R.R Tolkien\"");
            string bookEntry = Console.ReadLine();

            //Splits entry into parts
            string[] parts = bookEntry.Split(", ");
            if (parts.Length == 2)
            {
                //creates new book object
                Book newBook = new Book(parts[0], parts[1]);

                //adds newly created book instance to the context
               context.Books.Add(newBook);

                //ask context to save any changes to the database
                context.SaveChanges();

                Console.WriteLine("Successfully added book to database.");
            }
            else
            {
                Console.WriteLine("Invalid entry, only input title and author of book");
            }

            Console.WriteLine("The current list of books are: ");

            foreach (Book b in context.Books)
            {
                Console.WriteLine("{0} - {1} | {2}",b.ID, b.Title, b.Author);
            }
        }
    }
}