using System;
using System.Collections.Generic;
using System.Text;

namespace CheckersProgram
{
    class Game
    {
        private Board board;
        public Game()
        {
            this.board = new Board();
        }

        #region DrawBoard Method
        public void DrawBoard()
        {
            String[][] grid = new string[8][];
            for(int r=0; r < 8; r++)
            {
                grid[r] = new string[8];
                for(int c = 0; c < 8; c++)
                {
                    grid[r][c] = " ";
                }
            }

            foreach(Checker c in board.checkers)
            {
                grid[c.position.row][c.position.col] = c.Symbol;
            }

            Console.WriteLine(" 0 1 2 3 4 5 6 7");
            for(int r = 0; r < 8; r++)
            {
                Console.Write(r);
                for(int c = 0; c < 8; c++)
                {
                    Console.Write(" {0}", grid[r][c]);
                }

                Console.WriteLine();
            }
        }
        #endregion

        public void ProcessInput()
        {
            Console.WriteLine("Select a checker to move:");
            string checkerSelect = Console.ReadLine();

            Console.WriteLine("Select a square to move to:");
            string positionSelect = Console.ReadLine();
        }
    }
}
