using System.Collections.Generic;

namespace CheckersProgram
{
    internal class Board
    {
        //Board properties
        public List<Checker> checkers { get; private set; }

        #region Board Constructor
        //instantiates game pieces and sets initial position
        //adds game pieces to the List<Checkers> checkers
        public Board()
        {
            checkers = new List<Checker>();

            for (int r = 0; r < 3; r++)
            {
                for (int i = 0; i < 8; i += 2)
                {
                    Checker c = new Checker(Color.White, r, (r + 1) % 2 + i);
                    checkers.Add(c);
                }
                for (int i = 0; i < 8; i += 2)
                {
                    Checker c = new Checker(Color.Black, 5 + r, (r) % 2 + i);
                    checkers.Add(c);
                }
            }
        }
        #endregion 

        #region GetChecker Method
        public Checker GetChecker(Position source)
        {
            foreach (Checker c in checkers)
            {
                if (c.CheckerPosition.row == source.row && c.CheckerPosition.col == source.col)
                {
                    return c;
                }
            }
            return null;
        }
        #endregion

        #region MoveChecker Method
        public void MoveChecker(Checker iCheckerPos, Position destination)
        {
            Checker newChecker = new Checker(iCheckerPos.Team, destination.row, destination.col);
            checkers.Add(newChecker);
            checkers.Remove(iCheckerPos);
        }
        #endregion

        #region RemoveChecker Method
        public void RemoveChecker(Checker checker)
        {
            if(checker != null)
            {
                checkers.Remove(checker);
            }
        }
        #endregion

    }
}