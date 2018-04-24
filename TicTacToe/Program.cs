﻿
using System;
using System.Threading;

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
            Thread.Sleep(2000);
            
            

            
            


            
            
        }

        public static void PlaceMark(int row, int column)
        {
        
            if (playerTurn == "X")
            {   
                board[row][column] = playerTurn;
                CheckForWin();
                playerTurn = "O";  
                return;
                
            }  
            else if (playerTurn == "O")
            {
                board[row][column] = playerTurn; 
                CheckForWin();
                playerTurn = "X";  
                return;

            }                
        }    

           
        
       
        

        public static bool CheckForWin()
        {
            
            DiagonalWin();     
            HorizontalWin();
            VerticalWin();
            return false;
        }

        public static bool CheckForTie()
        {
            
            if(turn == 8)
            {
                Console.WriteLine("Y'ALL TIED");
                
            }

            return false;
        }
        
        public static bool HorizontalWin()
        {   
            
            if (board[0][0] == playerTurn && board[0][1] == playerTurn && board[0][2] == playerTurn || board[1][0] == playerTurn && board[1][1] == playerTurn && board[1][2] == playerTurn || board[2][0] == playerTurn && board[2][1] == playerTurn && board[2][2] == playerTurn )
            {
                Thread.Sleep(1000);
                Console.WriteLine(playerTurn + " " + "WINS");
            }

            return false;
        }

        public static bool VerticalWin()
        {
            if (board[0][0] == playerTurn && board[1][0] == playerTurn && board[2][0] == playerTurn || board[0][1] == playerTurn && board[1][1] == playerTurn && board[2][1] == playerTurn || board[0][2] == playerTurn && board[1][2] == playerTurn && board[2][2] == playerTurn )
            {
                Thread.Sleep(1000);
                Console.WriteLine(playerTurn + " " + "WINS");
            }
            
            return false;
        }

        public static bool DiagonalWin()
        {
            if (board[0][0] == playerTurn && board[1][1] == playerTurn && board[2][2] == playerTurn || board[0][2] == playerTurn && board[1][1] == playerTurn && board[2][0] == playerTurn )
            {
                Thread.Sleep(1000);
                Console.WriteLine(playerTurn + " " + "WINS");
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