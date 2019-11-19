using System;
using System.Collections.Generic;

namespace CarLot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Instantiation of Reagor CarLot
            CarLot Reagor = new CarLot("Reagor", new List<Vehicle>());

            //Instantiation of vehicles to be later added to Reagor CarLot
            Vehicle Rvehicle1 = new Car("Ford", "Mustang", "Coup", "2", "GTG123", "$34,000");
            Vehicle Rvehicle2 = new Truck("Ford", "F-150", "5ft", "WMN4567", "$50,000");
            Vehicle Rvehicle3 = new Car("Mazda", "Tribute", "SUV", "4", "HUY9876", "$12,000");
            
            //Instantiation of Tony's Used Cars CarLot
            CarLot TonyUsed = new CarLot("Tony's Used Cars", new List<Vehicle>());
            
            //Vehicles to go into Tony's Used Cars
            Vehicle Tvehicle1 = new Car("Ford", "Fusion", "Sedan", "4", "FFS4356", "$70,000");
            Vehicle Tvehicle2 = new Car("Tesla", "Model S", "Luxury Sedan", "4", "EEF6798", "$150,000");
            Vehicle Tvehicle3 = new Truck("Chevrolet", "Silverado", "10ft", "OOP2019", "$77,000");

            //Adding Vehicles to the Lot List
            Reagor.AddVehicle(Rvehicle1);
            Reagor.AddVehicle(Rvehicle2);
            Reagor.AddVehicle(Rvehicle3);
            
            //Printing the list
            Reagor.PrintList();

            //Adding Vehicles to Tony's Lot 
            TonyUsed.AddVehicle(Tvehicle1);
            TonyUsed.AddVehicle(Tvehicle2);
            TonyUsed.AddVehicle(Tvehicle3);
            
            //Printing the lot list
            TonyUsed.PrintList();

            Console.ReadLine();
        }
    }

    //CarLot Class
    internal class CarLot
    {
        //The class's properties of Name and a new List that wil hold the Vehicle class
        private string Name { get; set; }
        public List<Vehicle> CarList { get; set; }
        
        //The constructor for CarLot
        public CarLot(string iName, List<Vehicle> iCarList)
        {
            Name = iName;
            CarList = iCarList;
        }

        //The method to add vehicles to CarLot's list
        public virtual void AddVehicle(Vehicle vehicle)
        {            
                CarList.Add(vehicle);
            
        }

        //The method to print the CarLot's list
        public void PrintList()
        {
            Console.WriteLine("{0} Lot List:", Name);
            foreach (Vehicle vehicle in CarList)
            {
                Console.WriteLine(vehicle.Description());
            }
            Console.WriteLine("-----------------");
        }
    }

    //Abstract class of vehicle
    internal abstract  class Vehicle
    {
        //Properties for Vehicles 
        public string LicenseNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }

        //Empty constructor 
        public Vehicle()
        {
        }

        //Constructor that requires more specificty to instantiate an object of Vehicle class 
        public Vehicle(string iMake, string iModel, string iLicenseNumber, string iPrice)
        {
            Make = iMake;
            Model = iModel;
            LicenseNumber = iLicenseNumber;
            Price = iPrice;
        }

        //The method that displays the description of the vehicle object
        public virtual string Description()
        {
            return $"\nCarID:{LicenseNumber}\nMake/Model:{Make} {Model}\nPrice:{Price}\n";
        }
    }

    //Truck class, that is derived from Vehicle class - Holds all properties of Vehicle 
    internal class Truck : Vehicle
    {
        //Bedsize property is solely for the Truck class
        private string BedSize { get; set; }

        //Method to print the description of the Truck with it's own set of properties 
        public override string Description()
        {
            return $"\nCarID:{LicenseNumber}\nMake/Model:{Make} {Model}\nBed size:{BedSize}\nPrice:{Price}\n";
        }

        //Truck constructor that requires the Vehicles class properties, along with it's own property to instantiate the object 
        public Truck(string iMake, string iModel, string iBed , string iLicenseNumber, string iPrice) : base(iMake, iModel, iLicenseNumber, iPrice)
        {
             BedSize = iBed;

        }
    }

    //Car class, which is derived from Vehicle class
    class Car : Vehicle
    {
        //Car's own distinct properties
        string Type { get; set; }
        string DoorCount { get; set; }

        //Car's description method that displays it's own set of properties
        public override string Description()
        {
            return $"\nCarID:{LicenseNumber}\nMake/Model:{Make} {Model}\nStyle:{Type}\n{DoorCount} door\nPrice:{Price}\n";
        }

        //Car constructor that requires Vehicles properties and also the Car's specific properties to instantiate a Car object
        public Car(string iMake, string iModel, string iType, string iDoorCount, string iLicenseNumber, string iPrice) : base(iMake, iModel, iLicenseNumber, iPrice)
        {
            Type = iType;
            DoorCount = iDoorCount;
        }
    }
}