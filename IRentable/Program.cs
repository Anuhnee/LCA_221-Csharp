using System;
using System.Collections.Generic;

namespace IRentable
{
    class Program
    {
        static void Main(string[] args)
        {
            //List to hold my IRentable items 
            List<IRentable> Inventory = new List<IRentable>();

            //Car item
            Car Car1 = new Car("$45.00", "\nFord Mustang");
            //House item
            House House1 = new House("$100.00", "\n4bed - 2bath - 1000sq ft");
            //Boat item
            Boat Boat1 = new Boat("$20.00", "\n2 person paddle boat");

            //Adding the items to my list
            Inventory.Add(Car1);
            Inventory.Add(House1);
            Inventory.Add(Boat1);

            //Loop to print out the rates and descriptions for every item in list
            foreach(IRentable item in Inventory)
            {
                item.GetDescription();
                item.GetRate();
            }
            Console.ReadLine();
        }

        //IRentable interface creation
        public interface IRentable
        {
            //Methods within the interface
            void GetRate();
            void GetDescription();
        }

        //Car class, derived from IRentable
        public class Car : IRentable
        {
            public string Rate { get; set; }
            public string Description { get; set; }

            //Constructor
            public Car(string DailyRate, string iDesc)
            {
                Rate = DailyRate;
                Description = iDesc;
            }
            //Methods that must be used
            public void GetRate()
            {
                Console.WriteLine("{0} per day", Rate);
            }

            public void GetDescription()
            {
                Console.WriteLine("{0}", Description);
            }
        }

        //House class, derived from IRentable
        public class House : IRentable
        {
            public string Rate { get; set; }
            public string Description { get; set; }

            //Constructor
            public House(string WeeklyRate, string iDesc)
            {
                Rate = WeeklyRate;
                Description = iDesc;
            }

            //Methods that must be used
            public void GetRate()
            {
                Console.WriteLine("{0} per week.", Rate);
            }

            public void GetDescription()
            {
                Console.WriteLine("{0}", Description);
            }
        }

        //Boat class, derived from IRentable
        public class Boat : IRentable
        {
            public string Rate { get; set; }

            public string Description { get; set; }

            //Constructor
            public Boat(string HourlyRate, string iDesc)
            {
                Rate = HourlyRate;
                Description = iDesc;
            }

            //Methods that must be used 
            public void GetRate()
            {
                Console.WriteLine("{0} per hour", Rate);
            }

            public void GetDescription()
            {
                Console.WriteLine("{0}", Description);
            }
        }
    }
}
