using System.Collections.Generic;

namespace CheckersProgram
{
    internal class Board
    {
        //Board properties
        public List<Checker> checkers { get; private set; }

        //Board constructor
        //instantiates game pieces and sets initial position
        //adds game pieces to the List<Checkers> checkers
        public Board()
        {
            checkers = new List<Checker>();

            for (int r = 0; r < 3; r++)
            {
                for (int i = 0; i < 8; i += 2)
                {
                    Checker c = new Checker(Checker.Color.White, r, (r + 1) % 2 + i);
                    checkers.Add(c);
                }
                for (int i = 0; i < 8; i += 2)
                {
                    Checker c = new Checker(Checker.Color.Black, 5 + r, (r) % 2 + i);
                    checkers.Add(c);
                }
            }
        }

        public void GetChecker(Checker.Position position )
        {

        }


    }
}