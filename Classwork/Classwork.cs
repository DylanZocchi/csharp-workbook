using System;
using System.Threading;
using System.Linq;
// Add to your Mammal class that they are not venomous, don't have beaks, and don't lay eggs.
// Add that all birds can fly(): "Flap, flap, flap!"
// Create a Platypus class, which actually is venomous, has a beak, and lays eggs.
// Create a Penguin class that doesn't fly. "I can't fly!"

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {   
            Vertibrate vert = new Vertibrate();
            Bird bluejay = new Bird();
            NonFlyingBird penguin = new NonFlyingBird();
            Platypus platypus  = new Platypus();


            Console.WriteLine("hi");
        }
    }

    class Animal
    {
        public void eat()
        {
            Console.WriteLine("nom,nom,nom");

        }
        public void breath()
        {
            Console.WriteLine("Breathin, Breathout");

        }
    }
    class Mammal : Animal
    {
        public bool births = true;

        public virtual void nonvenomous()
        {
            Console.WriteLine("We Non Venomus");
        }

        public virtual void beakless()
        {
            Console.WriteLine("No beaks");
        }

        public virtual void noEggs()
        {
            Console.WriteLine("We lay no eggs");
        }
        

    }

    class Platypus : Mammal
    {
        public override void nonvenomous()
        {
            Console.WriteLine("We venomous");
        }
        public override void noEggs()
        {
            Console.WriteLine("We lay eggs");
        }

        public override void beakless()
        {
            Console.WriteLine("Got beaks");
        }


    }

    class Vertibrate : Animal
    {
        public bool backbone = true;

    }
     class Inertibrates : Animal
    {
        public bool backbone = false;

    }

     class Bird : Vertibrate
    {
        public bool feathers = true;

        public bool hatches = true;
        public virtual void fly()
        {
            Console.WriteLine("flap,flap,flap");
        }


    }

    class NonFlyingBird : Bird
    {
        public override void fly()
        {
            Console.WriteLine("No dice");
        }
    }




}