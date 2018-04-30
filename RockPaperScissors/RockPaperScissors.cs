using System;
using System.Threading;

namespace RockPaperScissors
{
    class Program
    {
        public static short h1s = 0;
        public static short h2s = 0;
        public static void Main()
        {   
            string[] rps = { "rock", "paper", "scissors",};
            
            while (h1s < 5 && h2s < 5)
            {
                Console.WriteLine("Enter hand 1:");
                string hand1 = Console.ReadLine().ToLower();
                Thread.Sleep(2000);

                Console.WriteLine("Hand 2:");
                Thread.Sleep(2000);

                //Random answer (string)
                //string[] rps = { "rock", "paper", "scissors",};
                string hand2 = rps[new Random().Next(0,3) ].ToLower();

            
                Console.WriteLine(hand2);
                Console.WriteLine(CompareHands(hand1, hand2));
                Thread.Sleep(2000);
            }

            //short h1s = 0;
            //short h2s = 0;
            
        

        public static string CompareHands(string hand1, string hand2)
            
        {
            if (hand1 == hand2)
            {
                return "It's a tie";
            }

                        
            if (hand1 == "rock")
            {
                if (hand2 == "scissors")
                {
                h1s++;
                return "Hand one wins!";  
                // h1s++;
                                
                }
                if (hand2 == "paper")
                {
                h2s++;
                return "Hand two wins!"; 
                // h2s++;
                
                               
                }
            }
            if (hand2 == "rock")
            {
                if (hand1 == "scissors")
                {
                    h2s++;
                    return "Hand two wins!"; 
                    // h2s++;
                }
                if (hand1 == "paper")
                {
                    h1s++;
                    return "Hand one wins!";  
                    // h1s++;
                                 
                }
            }
            if (hand1 == "paper")
            {
                if (hand2 == "scissors")
                {
                    h2s++;
                    return "Hand two wins!"; 
                    // h2s++;                  
                }
                if (hand2 == "rock")
                {   
                    h1s++;
                    return "Hand one wins";
                    // h1s++;
                    
                }
            }
            if (hand2 == "paper")
            {
                if (hand1 == "scissors")
                {
                    return "Hand one wins!"; 
                    // h1s++;              
                }
                if (hand2 == "rock")
                {
                    return "Hand two wins!";
                    // h2s++;   
                }
                return "Not a valid entry";
            }
        }
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



