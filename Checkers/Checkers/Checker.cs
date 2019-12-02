using System;

namespace CheckersProgram
{
    public class Checker
    {
        public String Symbol { get; private set; }
        public Color Team { get; private set; }
        public Position CheckerPosition { get; set; }



        public Checker(Color Team, int row, int col)
        {
            CheckerPosition = new Position(row, col);

            SetSymbol(Team);
        }

        #region SetSymbol Method

        public void SetSymbol(Color player)
        {
            if (player == Color.Black)
            {
                int symbol = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
                Symbol = char.ConvertFromUtf32(symbol);
                Team = Color.Black;
            }
            else
            {
                int symbol = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
                Symbol = char.ConvertFromUtf32(symbol);
                Team = Color.White;
            }
        }

        #endregion SetSymbol Method
    }

    public enum Color { White, Black }

    public struct Position
    {
        public int row { get; private set; }
        public int col { get; private set; }

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

    }
}