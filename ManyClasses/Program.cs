using System;
using System.Collections.Generic;

namespace ManyClasses
{
    class Program
    {
        static void Main(string[] args)
        {   //Drive License Instance
            DriverLicense driver1 = new DriverLicense("Anthony", "Perez", "Male", "123456");
            string FullName = driver1.GetFullName();
            Console.WriteLine(FullName);
            
            //Book Instance
            Book book1 = new Book("Book Title", "Author" , 500, 4368, "Penguin Publishing", 88.60);
            Console.WriteLine();

            //Plane Instance
            Airplane airplane1 = new Airplane("Boeing", "Model-1", "Variant 5", 50, 5);
            Console.WriteLine("The {0} {1} {2}, holds {3} passengers and has {4} engines!", airplane1.planeManufac, airplane1.planeModel, airplane1.planeVariant, airplane1.planeSeats, airplane1.planeEngines);
        }

        public class DriverLicense
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public string LicenseNumber { get; set; }
            public string GetFullName()
            {
                string FullName = FirstName + " " + LastName;

                return FullName;
            }

            public DriverLicense(string initialFirst, string initialLast, string initialGender, string initialLicenseNumber)
            {
                FirstName = initialFirst;
                LastName = initialLast;
                Gender = initialGender;
                LicenseNumber = initialLicenseNumber;
                
            }

        }

        public class Book
        {
            public string bookTitle { get; set; }
            public string bookAuthor { get; set; }
            public int bookPages { get; set; }
            public int bookSKU { get; set; }
            public string bookPublisher { get; set; }
            public double bookPrice { get; set; }

            public Book (string initialTitle, string initialAuthor, int initialPages, int initialSKU, string initialPublisher, double initialPrice)
            {
                bookTitle = initialTitle;
                bookAuthor = initialAuthor;
                bookPages = initialPages;
                bookSKU = initialSKU;
                bookPublisher = initialPublisher;
                bookPrice = initialPrice;
            }
                

        }

        public class Airplane
        {
            public string planeManufac { get; set; }
            public string planeModel { get; set; }
            public string planeVariant { get; set; }
            public int planeSeats { get; set; }
            public int planeEngines { get; set; }

            public Airplane(string initialManufac, string initialModel, string initialVariant, int initialSeats, int initialEngines)
            {
                planeManufac = initialManufac;
                planeModel = initialModel;
                planeVariant = initialVariant;
                planeSeats = initialSeats;
                planeEngines = initialEngines;
            }
        }
    }
}
