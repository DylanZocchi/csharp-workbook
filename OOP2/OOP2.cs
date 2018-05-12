using System;

namespace OOP2
{
    class Program
    {
        static void Main() //method
        {
            Garage smallGarage = new Garage(2);
            Car blueCar = new Car ("blue");
            Car redCar = new Car ("red");
            smallGarage.ParkCar(redCar,1);
            smallGarage.ParkCar(blueCar,0);
            Person oldPerson = new Person("old");
            Person youngPerson = new Person("young");
            //blueCar.Person(oldPerson);

            Console.WriteLine(smallGarage.Cars);
        }
    }

    class Car //object  General idea of what produces a car
    {
        //private Person[] persons;
        public int seats;
        public Car (string initalColor, int seats)
        {
            Color = initalColor;
            this.seats = seats;
            this.= new Car[size];

            
        }
       public string Color {get; private set;} //properties because its not private

       
    }
    // class Remove //object  General idea of what produces a car
    // {

    //    public Remove (string remove)
    //    {   
    //       remove = "remove";
    //    }
    //    public string remove {get; private set;} //properties because its not private
    // }


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
            cars[spot] = car;
        }
       
        public void RemoveCar(int spot)
        {
            
            cars[spot] = null;
            
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
