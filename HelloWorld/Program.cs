using System;

namespace HelloWorld
{
    class Program
    {
        public static void Main()
	{
		string outside = "daytime";
		string lights = "";

		if (outside == "daytime")
		{
		lights = "off";
		}
		else
		{
		lights = "on";
		}


		string lights = (outside == "daytime)") ? "on" : "off";
		Console.WriteLine("Turn the lights {0}", lights);

		string color = "green";
		switch (color)
		{
				case "green":
				Console.WriteLine("Must be St.Patrics DAy");
				break;

				case "white":
				Console.WriteLine("NOt after labor Day");
				break;

				default:
				Console.WriteLine("I don't know that one!");
				break;

		}

		}
		// string name = "";
		// int cats = 0;
		// string why = "";
        // int wish = 0;
		
		// Console.WriteLine("Please enter your name: ");
		// name = Console.ReadLine();
		// Console.WriteLine("How many cats do you have: ");
		// cats = Convert.ToInt32(Console.ReadLine());
		// Console.WriteLine("Why do you have so many cats dude?: ");
		// why = Console.ReadLine();
        // Console.WriteLine("How many cats would you like to get rid of?:");
        // wish = Convert.ToInt32(Console.ReadLine());
		
		// Console.WriteLine("Hello! My name is {0} and I have {1} nasty ass cats. Why do I have these cats? {2}. I wish I had {3} cats!", name, cats, why, cats - wish);
	}
    }
}
