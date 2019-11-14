using System;
using System.Collections.Generic;

namespace Heroes_Villains
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Person> People = new List<Person>();

            Person Bill = new Person("Bill Jenkins", "Jo-Bob-Jenkins");
            Person Jeff = new Person("Jeff Jefferson", "Nickelback");
            Person Lola = new Person("Lola Lavender", "LoLo");

            Superhero SpiderMan = new Superhero("SpiderMan", "Peter Parker", "Shoot webs, climb walls and a bunch of other cool stuff!", null);

            Villain GreenGoblin = new Villain("Harry Osborne", "SpiderMan", null);

            People.Add(Bill);
            People.Add(Jeff);
            People.Add(Lola);
            People.Add(SpiderMan);
            People.Add(GreenGoblin);

            foreach (Person human in People)
            {
                human.Greeting();
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public Person()
        {
        }

        public Person(string iName, string iNickname)
        {
            Name = iName;
            Nickname = iNickname;
        }


        public virtual void Greeting()
        {
            Console.WriteLine("{0}: Hello, my name is {1} but you can call me {2}.", Name, Name, Nickname);
        }
    }

    internal class Superhero : Person
    {
        public string RealName { get; set; }
        public string SuperPower { get; set; }

        public Superhero(string Name, string iRealName, string iSuperPower, string Nickname) : base(iName, Nickname)
        {
            SuperPower = iSuperPower;
            RealName = iRealName;
            Nickname = null;
        }

        public override void Greeting()
        {
            Console.WriteLine("\n{0}: I am {1}. When I am {2} I have the ability to {3}!",Name, RealName, Name, SuperPower);
        }
    }

    internal class Villain : Person
    {
        public string Nemesis;

        public Villain(string Name, string iNemesis, string Nickname) : base(Name, Nickname)
        {
            Nemesis = iNemesis;
            Nickname = null;
        }

        public override void Greeting()
        {
            Console.WriteLine("\n{0}: I am {1}! I can't wait to squash {2}!",Name, Name, Nemesis);
        }
    }
}