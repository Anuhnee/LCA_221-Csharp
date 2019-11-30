using System;

namespace Database_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate an instance of the context
            StudentsContext context = new StudentsContext();

            // makes sure that the table exists, 
            //and creates it if it does not already exist
            context.Database.EnsureCreated();

            // ask the user for a student to add
            Console.WriteLine("Enter Student full name");
            String fullName = Console.ReadLine();

            // split the input into parts, and make sure 
            // we have 2 parts only
            String[] parts = fullName.Split();
            if (parts.Length == 2)
            {
                // create a new student object, notice that we do not 
                // select an id, we let the framework handle that
                Student newStudent = new Student(parts[0], parts[1]);

                // add the newly created student instance to the context
                // notice how similar this is to adding a item to a list,
                context.Students.Add(newStudent);

                // ask the context to save any changes to the database 
                context.SaveChanges();
                Console.WriteLine("Added the student.");
            }
            else
            {
                Console.WriteLine("Invalid full name, did not add student");
            }

            Console.WriteLine("The Current List of students are: ");
            // use a for each loop to loop through the students in the context
            // notice how similar this is to looping through a list
            foreach (Student s in context.Students)
            {
                Console.WriteLine("{0} - {1} {2}",
                     s.Id, s.FirstName, s.LastName);
            }

        }
    }
}
