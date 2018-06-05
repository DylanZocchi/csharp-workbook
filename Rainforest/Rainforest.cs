using System;
using System.Collections.Generic;
					

namespace Rainforest
{
    class Program
    {
        static void Main(string[] args)
        {
            Company rainforest = new Company("Rainforest, LLC");


            //THIS DOES ALL THAT HIDEN SHIT BELOW
            string[] cities = new string[] {"Austin", "Houston", "San Antonio", "Dallas"};
            //string[] items = new string[] {"Banana", "Toothpaste", "Baseball", "Laptop"};
            string[] items = System.IO.File.ReadAllLines(@"./items.txt");
            
            foreach (var city in cities)
            {
                Warehouse warehouse = new Warehouse(city, 2);
                rainforest.warehouses.Add(warehouse);
            }

            // Warehouse austin = new Warehouse("Austin", 2);
            // Warehouse houston = new Warehouse("Houston", 3);
            // Warehouse dallas = new Warehouse("Dallas", 1);
            // Warehouse sanantonio = new Warehouse("San Antonio", 2);

            // rainforest.warehouses.Add(austin);
            // rainforest.warehouses.Add(houston);
            // rainforest.warehouses.Add(dallas);
            // rainforest.warehouses.Add(sanantonio);

           
            
            //adds containers to warehouses
            for(int i = 0; i < rainforest.warehouses.Count; i++)
            {
                Warehouse warehouse = rainforest.warehouses[i];
                Container container = new Container($"{warehouse.location}-1", i+1);
                rainforest.warehouses[i].containers.Add (container);
                
            }
  
            for (int i = 0; i < rainforest.warehouses.Count; i++)
            {
                Container container = rainforest.warehouses[1].containers[0];
                Item item = new Item(items[i], i);
                container.items.Add(item);
            }


        
            Console.WriteLine("ay");
            Console.ReadLine();
        }
    }
    class Company
    {
        public string name;
        public List<Warehouse> warehouses;

        public Company(string name)
        {
            this.name = name;
            this.warehouses = new List<Warehouse>();
        }

        

    }
    class Warehouse
    {
        public string location;
        public int size;

        
        public List<Container> containers;

        
        public Warehouse(string location, int size)
        {
            this.location = location;
            this.size = size;
            this.containers = new List<Container>();
        }

        public string AddContainer(Container container)
        {
            if(this.containers.Count < this.size)
            {
                this.containers.Add(container);
                return "Container Added";

            }
            return "NO MORE ROOM";
        }



    }
    class Container
    {
        public List<Item> items;
        public int size;
        public string id;


         //constructor funtion
        public Container(string id, int size)
        {
            this.id = id;
            this.size = size;
            this.items = new List<Item>();
        }


    }
    class Item
    {
        public string name;
        public double price;

         //constructor funtion
        public Item(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

    }
}
