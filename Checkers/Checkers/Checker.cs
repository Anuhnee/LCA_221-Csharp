using System;

namespace CheckersProgram
{
    internal class Checker
    {
        public String Symbol { get; private set; }
        public Color team { get; private set; }
        public Position position { get; private set; }

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

        public Checker(Color Team, int row, int col)
        {
            position = new Position(row, col);

            SetSymbol(Team);
        }

        public void SetSymbol(Color team)
        {
            if (team == Color.Black)
            {
                int symbol = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
                //string openCircle = char.ConvertFromUtf32(symbol);
                string  Blacksymbol = char.ConvertFromUtf32(symbol);

                Console.Write(Blacksymbol);
            }
            else 
            {
                int symbol = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
                //string closedCircle = char.ConvertFromUtf32(closedCircleId);
                Symbol = char.ConvertFromUtf32(symbol);
            }

        }
    }
}