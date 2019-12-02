using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckersProgram
{
    internal class Game
    {
        private Board board;

        public Game()
        {
            this.board = new Board();
        }

        public void Start()
        {
            do
            {
                DrawBoard();
                ProcessInput();
                Console.Clear();
            }
            while (!CheckForWin());

            Console.WriteLine("You Won!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        #region DrawBoard Method

        public void DrawBoard()
        {
            String[][] grid = new String[8][];
            for (int r = 0; r < 8; r++)
            {
                grid[r] = new String[8];
                for (int c = 0; c < 8; c++)
                {
                    grid[r][c] = " ";
                }
            }
            foreach (Checker c in board.checkers)
            {
                grid[c.CheckerPosition.row][c.CheckerPosition.col] = c.Symbol;
            }

            Console.WriteLine("   0   1   2   3   4   5   6   7");
            Console.Write("  ");
            for (int i = 0; i < 32; i++)
            {
                Console.Write("\u2015");
            }
            Console.WriteLine();

            for (int r = 0; r < 8; r++)
            {
                Console.Write($"{r} ");
                for (int c = 0; c < 8; c++)
                {
                    Console.Write($" {grid[r][c]} \u007C"); // Console.Write(" {0}", grid[r][c]);
                }
                Console.WriteLine();
                Console.Write("  ");
                for (int i = 0; i < 32; i++)
                {
                    Console.Write("\u2015");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region CheckForWin Method
        public bool CheckForWin()
        {
            return (board.checkers.All(x => x.Team == Color.White) || board.checkers.All(x => x.Team == Color.Black));
        }
        #endregion

        public bool IsLegalMove(Color player, Position source, Position destination)
        {
            //Source position and destination position
            //must be between 0 and 7
            if (source.row < 0 || source.row > 7 || source.col < 0 || source.col > 7
               || destination.row < 0 || destination.row > 7 || destination.col < 0
               || destination.col > 7) return false;

            //The row distance between the destination position and source position
            //must be larger than 0 and less than or equal to 2
            //Ensures checker moves diagonal
            int rowDistance = Math.Abs(destination.row - source.row);
            int colDistance = Math.Abs(destination.col - source.col);

            if (colDistance == 0 || rowDistance == 0) return false;

            if (rowDistance / colDistance != 1) return false;

            if (rowDistance > 2) return false;

            Checker c = board.GetChecker(source);
            if(c == null) //No checker at source position
            {
                return false;
            }

            c = board.GetChecker(destination);
            if (c != null) //destination is occupied
            {
                return false;
            }

            if(rowDistance == 2)
            {
                if(IsCapture(source, destination))
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        public bool IsCapture(Position source, Position destination)
        {
            int rowDistance = Math.Abs(destination.row - source.row);
            int colDistance = Math.Abs(destination.col - source.col);
            if(rowDistance == 2 && colDistance == 2)
            {
                int rowMid = (destination.row + source.row) / 2;
                int colMid = (destination.col + source.col) / 2;
                Position MiddlePosition = new Position(rowMid, colMid);
                Checker midChecker = board.GetChecker(MiddlePosition);

                if(midChecker == null)
                {
                    return false;
                }
                Checker player = board.GetChecker(source);
                if(midChecker.Team != player.Team)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public Checker GetCapture(Position source, Position destination)
        {
            if (IsCapture(source, destination))
            {
                int rowMid = (destination.row + source.row) / 2;
                int colMid = (destination.col + source.col) / 2;
                Position pos = new Position(rowMid, colMid);
                Checker MidChecker = board.GetChecker(pos);
                return MidChecker;
            }
            return null;
        }




        public void ProcessInput()
        {
            Console.WriteLine("Select a checker to move (Row, Column):");
            string[] checkerSelect = Console.ReadLine().Split(",");

            Console.WriteLine("Select a destination (Row, Column):");
            string[] destinationSelect = Console.ReadLine().Split(",");

            Position from = new Position(int.Parse(checkerSelect[0]), int.Parse(destinationSelect[1]));

            Position to = new Position(int.Parse(destinationSelect[0]), int.Parse(destinationSelect[1]));

            Checker srcChecker = board.GetChecker(from);

            if(srcChecker == null)
            {
                Console.WriteLine("Invalid source position, try again.");
            }

            else
            {
                if (IsLegalMove(srcChecker.Team, from, to))
                {
                    if(IsCapture(from, to))
                    {
                        board.MoveChecker(srcChecker, to);
                        Checker jumpChecker = GetCapture(from, to);
                        board.RemoveChecker(jumpChecker);
                    }
                    board.MoveChecker(srcChecker, to);
                }

                else
                {
                    Console.WriteLine("Invalid move. Check source and destination.");
                }
            }
            DrawBoard();
        }
    }
}