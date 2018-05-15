using System;

namespace OOP
{
    
    class Program //object
    {
        static void Main()
        {
            Person rebel = new Person("Leia", "Organa", "Rebel");
            Person imperial = new Person("Darth", "Vader","Imperial"); 
            Ship falcon = new Ship("Rebel", "Smuggling", 2);
		    Ship tie = new Ship("Tie", "Fighter", 1);
            Station imperialStation = new Station("Imperial", "Death Star", 100);
            Station rebelStation = new Station("Rebel", "Rebel Base", 50);
            Console.WriteLine("");
        }
    }
    class Person
    {
        private string firstName;
        private string lastName;
       
        private string alliance;
        public Person(string firstName, string lastName, string alliance)
        {
            this.firstName = firstName; //use this when your names are the same
            this.lastName = lastName;
            this.alliance = alliance;
            
        }
        public string FullName
        {
            get
            {
                return this.firstName + " " + this.lastName;
            }
            set
            {
                string[] names = value.Split(" ");
                this.firstName = names[0];
                this.lastName = names[1];
            }
        }

    }

    class Ship
    {
        //private string type; SEE GET AN SET BELOW
        //private string alliance; SEE GET AND SET BELOW
        private Person[] passengers;
        public Ship(string alliance, string type, int size)
        {
            this.Type = type;
            this.Alliance = alliance;
            this.passengers = new Person[size];
        }
        public string Type { get; set; }
        public string Alliance { get; set; }
        public string Passengers
        {
            get
            {
                foreach (var person in passengers)
                {
                    Console.WriteLine(String.Format("{0}", person.FullName));
                }
                return "that everyone";
            }

        }

        public void EnterShip(Person person, int seat)
        {
            this.passengers[seat] = person;
        }

        public void Exitship(int seat)
        {
            this.passengers[seat]= null;
        }


    }
    class Station
    {
        private Ship[] ships;
        private int shipCapacity;
        public string Name { get; set; }
        public string Alliance { get; set; }
        //public string people {get; set;}

        public Station(string alliance, string name, int shipCapacity)
        {
            this.shipCapacity = shipCapacity;
            this.Alliance = alliance;
            this.Name = name;
            this.ships = new Ship[100]; 
           // this.people = person;
            
        }

        public void Port(int location, Ship Ship)
        {
            ships[location] = Ship;  
        }











    }



}
