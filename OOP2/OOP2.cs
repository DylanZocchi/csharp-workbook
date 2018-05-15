using System;

namespace OOP2
{
    class Program
    {
        static void Main() //method
        {
            Garage smallGarage = new Garage(2);
            Car blueCar = new Car("blue", 4);
            Car redCar = new Car("red", 4);
            smallGarage.ParkCar(redCar,1);
            smallGarage.ParkCar(blueCar,0);
            Person oldPerson = new Person("old");
            Person youngPerson = new Person("young");
            blueCar.SeatPerson(oldPerson, 2);
            redCar.SeatPerson(youngPerson, 1);

            
            
            Console.WriteLine(smallGarage.Cars);

        }
    }

    public class Car //object  General idea of what produces a car
    {
        private Person[] passengers;
        public int Seats {get; private set;}

        public string Color {get; private set;} 

        public Car (string initalColor, int seats)
        {
            Color = initalColor;
            this.passengers = new Person[seats];
                    
        }

        public string Passengers
        {
            get
            {
                foreach (var person in passengers)
                {
                    Console.WriteLine(String.Format("{0}", person.Age));
                }
                return "that everyone";
            }
        }
       //public string Color {get; private set;} //properties because its not private

       public void SeatPerson(Person person, int seat)
        {
            this.passengers[seat] = person;
        }
       
        public void RemovePerson(int seat)
        {
            
            this.passengers[seat] = null;
        }

        
    }
    class Garage 
    {
        private Car[] cars;  

        public Garage(int size)
        {
            Size = size;
            this.cars = new Car[size];
        }

        public int Size {get; private set;}
        public void ParkCar(Car car, int spot)
        {
            this.cars[spot] = car;
        }
       
        public void RemoveCar(int spot)
        {
            
            this.cars[spot] = null;
            
        }
        public string Cars 
        {
            get 
            {
                //return $"Car in spot 0 is {cars[0].Color} and the car in spot 1 is {cars[1].Color}";
                for (int i = 0; i < cars.Length; i++)
                {
                    if (cars !=null) 
                    {
                        Console.WriteLine(String.Format("The {0} car is in spot {1}.", cars[i].Color, i));
                    }   
                }

                return "That's all";

            }
        }
    }
    
    public class Person
    {
        public Person(string age)
        {
            Age = age;
        }
        public string Age {get; private set;}

    
       
    }
}   
