using System;
using System.Threading;
using System.Linq;

namespace Checkpoint1
{
    class Program
    {
        static void Main(string[] args)
        {
            //one();
            //two();
            //three();
            //four();
            //five();

        }

        public static void one()
        {
            // 1- Write a program to count how many numbers between 1 and 100 are 
            // divisible by 3 with no remainder. Display the count on the console.
            
            int i = 3;
            int x = 100 / i;
            Console.WriteLine(x);                        
        }

        public static void two()
        {
            // Write a program and continuously ask the user to enter a number or "ok" to exit.
            // Calculate the sum of all the previously entered numbers and display it on the console.
                        
            int sum = 0;  
            bool exit = true;         
            while(exit)
            {
                Console.WriteLine("Enter a number or \"ok\" to exit");
                string i = Console.ReadLine().ToLower();
                    if ( i == "ok")
                    {
                        exit = false;
                        break;
                    }
                    try
                    {
                    sum += Convert.ToInt32(i);
                    Console.WriteLine("Sum = " + sum);
                    }
                    catch
                    {
                    Console.WriteLine("");
                    }                   
            }                      
        }

        public static void three()
        {

        // Write a program and ask the user to enter a number. Compute the factorial
        // of the number and print it on the console. For example, if the user enters 5,
        // the program should calculate 5 x 4 x 3 x 2 x 1 and display it as 5! = 120.
        
       
            int i; 
            int number; 
            double fact;
            Console.WriteLine("Enter the Number");
            number = int.Parse(Console.ReadLine());
            fact = number;
            for (i = number - 1; i >= 1; i--)
            {
                fact = fact * i;
            }
            Console.WriteLine("Factorial = " + fact);
            Console.ReadLine();
 
        }


        public static void four()
        {
        //Write a program that picks a random number between 1 and 10. Give the user 4
        //chances to guess the number. If the user guesses the number, display 
        //“You won"; otherwise, display “You lost".
        //(To make sure the program is behaving correctly,
        //you can display the secret number on the console first.)
         
            
            int turn = 1;
            Random rnd = new Random();
            int x = rnd.Next(1, 10);
            Console.WriteLine("SECRET NUMBER IS " + x);
            Thread.Sleep(1000);
            Console.WriteLine("");
            game();

            void game()
            {
                Console.WriteLine("Enter a number between 1 and 10:");
                int z = Convert.ToInt16(Console.ReadLine());

                if(x == z)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("///////");
                    Console.WriteLine("YOU WON"); 
                    Console.WriteLine("///////"); 
                    Console.WriteLine("");                  
                }

                if(turn == 4)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("/////////");
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine("/////////");
                    Console.WriteLine("");
                    return;                
                }

                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("/////////");
                    Console.WriteLine("TRY AGAIN");
                    Console.WriteLine("/////////");
                    Console.WriteLine("");
                    turn++;
                    game();
                }                         
            }               
        }

        public static void five()
        {
            // Write a program and ask the user to enter a series of numbers
            // separated by comma. Find the maximum of the numbers and display
            // it on the console. For example, if the user enters “5, 3, 8, 1, 4",
            // the program should display 8.
            
            int [] numbers = new int [10];
            Console.WriteLine("Enter a series of numbers separated by commas:");
            string [] x = Console.ReadLine().Split(',');
            for (int i = 0; i < x.Length; i ++)
            {
                numbers[i] = Convert.ToInt32(x[i]);

            }
            Console.WriteLine("MAX VAL = " + numbers.Max());

         }
    }
}

