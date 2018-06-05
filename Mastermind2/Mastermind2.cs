using System;
using System.Collections.Generic;

namespace Mastermind {
    class Program {
        static void Main (string[] args) 
        {
            Console.WriteLine("Choose four letters");
            string letters = Console.ReadLine();
            string[] lettersSplit = letters.Split(",");
            Ball[] balls = new Ball[4];
            for (int i = 0; i < 4; i++)
            {
                balls[i] = new Ball (lettersSplit[i]);
                Console.WriteLine(balls[i].Letter);
            }
            Row row1 = new Row(balls);
            Console.WriteLine(row1.Balls);

        }
        class Game
        {
            private List<Row> rows = new List <Row>();
        }
            

            public Game()
            {

            }

            public void AddRow()
            {
                this.rows.Add(row);
                

            }

        }
        class Ball
        {
            public string Letter { get; private set; }

            public Ball(string letter)
            {
                this.Letter = letter;
            }
        }
        
        //CONSTRUCTOR FUNCTION
        class Row
        {
            public Ball[] balls = new Ball[4];

            public Row(Ball[] balls) 
            {
                this.balls = balls;
            }

            //PROPERTY
            public string Balls 
            {
                get
                {
                    foreach (var ball in this.balls)
                    {
                        Console.Write(ball.Letter);
                    }
                    return " 1-1 ";

                }
                 

            }

        }

    }
}   