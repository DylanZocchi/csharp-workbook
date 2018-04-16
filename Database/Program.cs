using System;
using System.Threading;

namespace Database
{
    class Program
    {
 
        static void Main(string[] args)
        { 

        
            short complete = 0;

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Welcome to the cavern of secrets!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Thread.Sleep(2000);
		

            Console.WriteLine("You enter a dark cavern out of curiosity. It is dark and you can only make out a small stick on the floor.");
            string ch1 = "";
            Console.WriteLine("Do you take it? [y/n]:");
            ch1 = Console.ReadLine();
           
		

		
	
            //# STICK TAKEN
            short stick = 0;
            
            
            if (ch1 == "y" || ch1 == "Y" || ch1 == "Yes" || ch1 == "YES" || ch1 == "yes")
	        {
                Console.WriteLine("You have taken the stick!");
		        Thread.Sleep(1000);
                stick = 1;
            }
            
	    
            //STICK NOT TAKEN	
            else 
		    {
			    Console.WriteLine("You did not take the stick");
                Thread.Sleep(1000);
                
		    }


            Console.WriteLine("As you proceed further into the cave, you see a small glowing object");
            string ch2 = "";
            Thread.Sleep(1000);
            Console.WriteLine("Do you approach the object? [y/n]?: ");
            ch2 = Console.ReadLine();
            Thread.Sleep(1000);



            //APPROACH SPIDER
            if ( ch2 == "y" || ch2 == "Y" || ch2 == "Yes" || ch2 == "YES" || ch2 == "yes" )
		    {
			    Console.WriteLine("You approach the object...");
    		    Thread.Sleep(1000);
			    Console.WriteLine("As you draw closer, you begin to make out the object as an eye!");
    		    Thread.Sleep(1000);
    		    Console.WriteLine("The eye belongs to a giant spider!");
                Thread.Sleep(1000);
		    }

            else
            {
                Console.WriteLine("You turn away from the glowing object, and attempt to leave the cave...");
                Thread.Sleep(1000);
                Console.WriteLine("But something won't let you....");
                Thread.Sleep(1000);
            }

               	string ch3 = ("");
			    Console.WriteLine("Do you try to fight it? [y/n]");
			    ch3 = Console.ReadLine();

		

            //FIGHT SPIDER
            if ( ch3 == "y" || ch3 == "Y" || ch3 == "Yes" || ch3 == "YES" || ch3 == "yes" )
		    {
			    Thread.Sleep(1000);
                Console.WriteLine("Lets fight it!:");
                Thread.Sleep(1000);
		    }
		
            //DON'T FIGHT SPIDER
		    else 
		    {
                Console.WriteLine("You choose not to fight the spider.");
                Thread.Sleep(1000);
                Console.WriteLine("As you turn away, it ambushes you and impales you with it's fangs!!!");
                Thread.Sleep(1000);
                complete = 0;
                Game();
                return;
                
		    }


                

                if (stick == 1)
                {
                    Console.WriteLine("You only have a stick to fight with!");
                    Thread.Sleep(1000);
                    Console.WriteLine("You quickly jab the spider in it's eye and gain an advantage");
                    Thread.Sleep(1000);

                }
                else
		        {
                    Console.WriteLine("You don't have anything to fight with!");
                    Thread.Sleep(1000);

                }

                    Thread.Sleep(2000);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("                  Fighting...                   ");
                    Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                    Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Thread.Sleep(2000);






			    Random rnd = new Random();
			    int fdmg1 = rnd.Next(3, 10); // creates a number between 1 and 12

			    int edmg1 = rnd.Next(1, 5); // creates a number between 1 and 6

			    Console.WriteLine("you hit a + {0}", fdmg1);
                Thread.Sleep(2000);
			    Console.WriteLine("the spider hits a + {0}", edmg1);
                Thread.Sleep(2000);
		    

            if ( edmg1 > fdmg1 )
            {
                Console.WriteLine("The spider has dealt more damage than you!");
                complete = 0;
                Game();

            }
            

            else if ( fdmg1 < 5 )
            {
                Console.WriteLine("You didn't do enough damage to kill the spider, but you manage to escape");
                complete = 1;
                Game();
            }


            else 
			{
            Console.WriteLine("You killed the spider!");
            complete = 1;
            Game();
            
            } 

            string end = "";
            void Game()
            {               
                if ( complete == 1 )
                {    
                    Console.WriteLine("You managed to escape the cavern alive! Would you like to play again? [y/n]");
                }


                else
                {
                    Console.WriteLine("You have died! Would you like to play again? [y/n]");            
                } 

                     end = Console.ReadLine();

                    while ( end == "y")
		            {
		                 Main(args);
                         end = Console.ReadLine();

                        if(end == "n")
                        {
                            break;
                        }
                    }


                    
            }               

        }
        
    }   
}          
				