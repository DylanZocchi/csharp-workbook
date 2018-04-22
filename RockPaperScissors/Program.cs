using System;
using System.Threading;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {   
            
            Console.WriteLine("Enter hand 1:");
            string hand1 = Console.ReadLine().ToLower();
            Thread.Sleep(2000);

            Console.WriteLine("Hand 2:");
            Thread.Sleep(2000);

            //Random answer (string)
            string[] rps = { "rock", "paper", "scissors",};
            string hand2 = rps[new Random().Next(0,2) ].ToLower();

            
            Console.WriteLine(hand2);
            Thread.Sleep(2000);
            short h1s = 0;
            short h2s = 0;
            
        

            
            //Console.WriteLine(CompareHands(hand1, hand2));
            
            // Console.WriteLine("Hand One Score = {0}", h1s);
            // Console.WriteLine("Hand Two Score = {0}", h2s);
            // Thread.Sleep(2000);
            // Console.WriteLine("Would you like to play again? [y/n]");
            

            //LOOP GAME
            // String end = Console.ReadLine();

            //         while ( end == "y")
		    //         {
		    //             Main();
            //             end = Console.ReadLine();

            //             if(end == "n")
                        
            //             {
            //                 // break;
                            
            //             }
            //         }


            //leave this command at the end so your program does not close automatically
            //Console.ReadLine();
        //}

        //public static string CompareHands(string hand1, string hand2)
        //{

            if (hand1 == hand2)
            {
            Console.WriteLine("It's a tie");
            }

                        
            if (hand1 == "rock")
            {
                if (hand2 == "scissors")
                {
                Console.WriteLine("Hand one wins!");  
                h1s++;
                                
                }
                if (hand2 == "paper")
                {
                Console.WriteLine ("Hand two wins!"); 
                h2s++;
                
                               
                }
            }
            if (hand2 == "rock")
            {
                if (hand1 == "scissors")
                {
                Console.WriteLine("Hand two wins!"); 
                h2s++;
                }
                if (hand1 == "paper")
                {
                Console.WriteLine("Hand one wins!");  
                h1s++;
                                 
                }
            }
            if (hand1 == "paper")
            {
                if (hand2 == "scissors")
                {
                Console.WriteLine("Hand two wins!"); 
                h2s++;                  
                }
                if (hand2 == "rock")
                {
                    Console.WriteLine("Hand one wins");
                    h1s++;
                    
                }
            }
            if (hand2 == "paper")
            {
                if (hand1 == "scissors")
                {
                Console.WriteLine("Hand one wins!"); 
                h1s++;              
                }
                if (hand2 == "rock")
                {
                    Console.WriteLine("Hand two wins!");
                    h2s++;
                    
                }
            }
        
            
            //return hand1 + ' ' + hand2;
        
            Console.WriteLine("Hand One Score = {0}", h1s);
            Console.WriteLine("Hand Two Score = {0}", h2s);


            Thread.Sleep(2000);
            Console.WriteLine("Would you like to play again? [y/n]");

            String end = Console.ReadLine();

                    while ( end == "y")
		            {
		                Main();
                        end = Console.ReadLine();

                        if(end == "n")
                        
                        {
                            return;
                            
                        }
                    }
             Console.ReadLine();
        }       
    }
}



