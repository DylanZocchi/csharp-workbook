
using System;

namespace TicTacToe
{
    class Program
    {
        public static string playerTurn = "X";
        public static int turn = 0;
        

        
        public static string[][] board = new string[][]
        {
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "}
            
        };

        public static void Main()
        {
            do
            {
                DrawBoard();
                GetInput();

            } while (!CheckForWin() && !CheckForTie());
                
                    
                
            
        


            

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }

        public static void GetInput()
        {
            Console.WriteLine("Player " + playerTurn);
            Console.WriteLine("Enter Row:");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Column:");
            int column = int.Parse(Console.ReadLine());
            PlaceMark(row,column);
            turn += 1;

            
            


            
            
        }

        public static void PlaceMark(int row, int column)
        {
        // your code goes here
           
            //board[row][column] = "X";
            if (playerTurn == "X")
            {
                playerTurn = "O";
                board[row][column] = "X";
                
            }
            else
            {
                playerTurn = "X";
                board[row][column] = "O";
            }   
                
        }    
        
       
        

        public static bool CheckForWin()
        {
            // your code goes here
            if (DiagonalWin() == true)
                Console.WriteLine ("GAME OVER");
                
            else if (HorizontalWin() == true)
            {
                Console.WriteLine ("GAME OVER");
                   
            }
            else if(VerticalWin() == true)
            {
                Console.WriteLine ("GAME OVER");
                
            }
            
            
            return false;
        }

        public static bool CheckForTie()
        {
            // your code goes here
            if(turn == 8)
            {
                Console.WriteLine("Y'ALL TIED");
                
            }

            return false;
        }
        
        public static bool HorizontalWin()
        {   
            
            if (board[0][0] == "X" && board[0][1] == "X" && board[0][2] == "X" || board[1][0] == "X" && board[1][1] == "X" && board[1][2] == "X" || board[2][0] == "X" && board[2][1] == "X" && board[2][2] == "X" )
            {
                Console.WriteLine("X WINS");
            }
            else if (board[0][0] == "O" && board[0][1] == "O" && board[0][2] == "O" || board[1][0] == "O" && board[1][1] == "O" && board[1][2] == "O" || board[2][0] == "O" && board[2][1] == "O" && board[2][2] == "O")
            {
                Console.WriteLine("O WINS");
            }

            return false;
        }

        public static bool VerticalWin()
        {
            if (board[0][0] == "X" && board[1][0] == "X" && board[2][0] == "X" || board[0][1] == "X" && board[1][1] == "X" && board[2][1] == "X" || board[0][2] == "X" && board[1][2] == "X" && board[2][2] == "X" )
            {
                Console.WriteLine("X WINS");
            }
            else if (board[0][0] == "O" && board[1][0] == "O" && board[2][0] == "O" || board[0][1] == "O" && board[1][1] == "O" && board[2][1] == "O" || board[0][2] == "O" && board[1][2] == "O" && board[2][2] == "O" )
            {
                 Console.WriteLine("O WINS");
            }
            
            return false;
        }

        public static bool DiagonalWin()
        {
            if (board[0][0] == "X" && board[1][1] == "X" && board[2][2] == "X" || board[0][2] == "X" && board[1][1] == "X" && board[2][0] == "X" )
            {
                Console.WriteLine("X WINS");
            }
            else if (board[0][0] == "O" && board[1][1] == "O" && board[2][2] == "O" || board[0][2] == "O" && board[1][1] == "O" && board[2][0] == "O" )
            {
                Console.WriteLine("O WINS");
            }
    
            return false;
        }

        public static void DrawBoard()
        {
            Console.WriteLine("  0 1 2");
            Console.WriteLine("0 " + String.Join("|", board[0]));
            Console.WriteLine("  -----");
            Console.WriteLine("1 " + String.Join("|", board[1]));
            Console.WriteLine("  -----");
            Console.WriteLine("2 " + String.Join("|", board[2]));
            
        }
    }
}