using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {     
            Game.Start();              
        }
    }

    public class Checker
    {
        public string Symbol  { get; set; }
        public int[] Position  { get; set; }
        public string Color { get; set; }
        
        public Checker(string color, int[] position)
        {
            int circleId;
            if (color == "black")
            {
                circleId = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
            }
            else
            {
                circleId = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
            }
            this.Symbol = char.ConvertFromUtf32(circleId);
            this.Position = position;
            this.Color = color;
        }
    }

    public class Board
    {
        public string[][] Grid  { get; set; }
        public List<Checker> Checkers { get; set; }
        
        public Board()
        {
            this.Checkers = new List<Checker>();
            this.CreateBoard();

            
            return;
        }
        
        public void CreateBoard()
        {
            this.Grid = new string[][] {
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
                new string[] {" ", " ", " ", " ", " ", " ", " ", " "},
            };
            
            return;
        }
        
        public void GenerateCheckers()
        {
            

            int[][] whitePositions = new int[][] {
                new int[] { 0, 1 }, new int[] { 0, 3 }, new int[] { 0, 5 }, new int[] { 0, 7 },
                new int[] { 1, 0 }, new int[] { 1, 2 }, new int[] { 1, 4 }, new int[] { 1, 6 },
                new int[] { 2, 1 }, new int[] { 2, 3 }, new int[] { 2, 5 }, new int[] { 2, 7 }
            };
            

            int[][] blackPositions = new int[][] {
                new int[] { 5, 0 }, new int[] { 5, 2 }, new int[] { 5, 4 }, new int[] { 5, 6 },
                new int[] { 6, 1 }, new int[] { 6, 3 }, new int[] { 6, 5 }, new int[] { 6, 7 },
                new int[] { 7, 0 }, new int[] { 7, 2 }, new int[] { 7, 4 }, new int[] { 7, 6 }
            };

            
            for (int i = 0; i < 12; i++)
            {
                Checker white = new Checker("white", whitePositions[i]);
                Checker black = new Checker("black", blackPositions[i]);
                this.Checkers.Add(white);
                this.Checkers.Add(black);
            }

            return;
        }
        
        public void PlaceCheckers()
        {
            foreach (var checker in Checkers)
            {
                this.Grid[checker.Position[0]][checker.Position[1]] = checker.Symbol;
            }
            return;
        }
        
        public void DrawBoard()
        {
            
            
            Console.WriteLine("  0 1 2 3 4 5 6 7");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(i + " " + String.Join(" ", this.Grid[i]));
            }
            return;
        }
        
        public Checker SelectChecker()
        {
            Console.WriteLine("Select checker row");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Select checker column");
            int col = Convert.ToInt32(Console.ReadLine());
                

                
            return Checkers.Find(x => x.Position.SequenceEqual(new List<int> { row, col }));
        }

        public void MoveChecker2(Checker checker)
        {
            Console.WriteLine("Move to which row");
            int newRow = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Move to which column");
            int newCol = Convert.ToInt32(Console.ReadLine());
            checker.Position = new int[]{newRow, newCol};
            
        }
        public bool MoveChecker(Checker checker)
        {

            Console.WriteLine("Move to which row");
            int newRow = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Move to which column");
            int newCol = Convert.ToInt32(Console.ReadLine());
            if (this.Grid[newRow][newCol]== " ")
            {
                if (checker.Color == "white")
                {
                    if (newRow < checker.Position[0])
                    {
                        if (newRow + newCol == checker.Position[0] + checker.Position[1] || newRow - newCol == checker.Position[0] - checker.Position[1])
                        {
                            checker.Position = new int[]{newRow, newCol};
                            return true;
                        }
                        
                    }
                }
                if (checker.Color == "black")
                {
                    if (newRow > checker.Position[0])
                    {
                        if (newRow + newCol == checker.Position[0] + checker.Position[1] || newRow - newCol == checker.Position[0] - checker.Position[1])
                        {
                            checker.Position = new int[]{newRow, newCol};
                            return true;
                        }
                        
                    }
                }

                
            }
            
            System.Console.WriteLine("Illegal Move:");
            return false;
            
        }
        
        public void DeleteChecker(int newRow, int oldRow, int newCol, int oldCol)
        {
            if (newRow - oldRow > 1)
            {
                int row = (oldRow + newRow) / 2;
                int col = (oldCol + newCol) / 2;
                RemoveChecker(Checkers.Find(x => x.Position.SequenceEqual(new List<int> { row, col })));
            }
            
        }
        public void EliminateChecker1(Checker checker)
        {
            if (checker.Color == "white")
                {
                    if (Grid[checker.Position[0]+1][checker.Position[1]-1] == "black")
                    {
                        Checker eliminatedChecker = Checkers.Find(x => x.Position.SequenceEqual(new List<int> { checker.Position[0]+1, checker.Position[1]-1}));
                        RemoveChecker(eliminatedChecker);

                    }
                }
                if (checker.Color == "black")
                {
                    if (Grid[checker.Position[0]+1][checker.Position[1]+1] == "white")
                    {
                        Checker eliminatedChecker = Checkers.Find(x => x.Position.SequenceEqual(new List<int> { checker.Position[0]+1, checker.Position[1]+1}));
                        RemoveChecker(eliminatedChecker);

                    }
                }
                if(checker.Color == "white")
                {
                    if (Grid[checker.Position[0]+1][checker.Position[1]+1] == "black")
                    {
                        Checker eliminatedChecker = Checkers.Find(x => x.Position.SequenceEqual(new List<int> { checker.Position[0]+1, checker.Position[1]+1}));
                        RemoveChecker(eliminatedChecker);

                    }
                }
        }
        public void EliminateChecker(bool isValid, Checker checker)
        {
            if (isValid)
            {
                if (checker.Color == "white")
                {
                    if (Grid[checker.Position[0]+1][checker.Position[1]-1] == "black")
                    {
                        Checker eliminatedChecker = Checkers.Find(x => x.Position.SequenceEqual(new List<int> { checker.Position[0]+1, checker.Position[1]-1}));
                        RemoveChecker(eliminatedChecker);

                    }
                }
                if (checker.Color == "black")
                {
                    if (Grid[checker.Position[0]+1][checker.Position[1]+1] == "white")
                    {
                        Checker eliminatedChecker = Checkers.Find(x => x.Position.SequenceEqual(new List<int> { checker.Position[0]+1, checker.Position[1]+1}));
                        RemoveChecker(eliminatedChecker);

                    }
                }
                if(checker.Color == "white")
                {
                    if (Grid[checker.Position[0]+1][checker.Position[1]+1] == "black")
                    {
                        Checker eliminatedChecker = Checkers.Find(x => x.Position.SequenceEqual(new List<int> { checker.Position[0]+1, checker.Position[1]+1}));
                        RemoveChecker(eliminatedChecker);

                    }
                }
            }

        }

        public void RemoveChecker(Checker checker)
        {
            if (checker == null)
            {
                return;
            }
            this.Checkers.Remove(checker);
            return;
        }
        
        public bool CheckForWin()
        {
            return Checkers.All(x => x.Color == "white") || !Checkers.Exists(x => x.Color == "white");
        }
    }

    class Game
    {
        public static void Start()
        {
            Board board = new Board();
            board.GenerateCheckers();
            
            board.PlaceCheckers();
            board.DrawBoard();
            while (!board.CheckForWin())
            {
                Checker temp = board.SelectChecker();
                int oldRow = temp.Position[0];
                int oldCol = temp.Position[1];
                board.MoveChecker2(temp);
                int newRow = temp.Position[0];
                int newCol = temp.Position[1];
                board.DeleteChecker(newRow, oldRow, newCol, oldCol);
                board.CreateBoard();
                board.PlaceCheckers();
                board.DrawBoard();
                if (board.CheckForWin())
                {
                    System.Console.WriteLine("Game Over!");
                    return;
                }
            }       
        }
    }
}
