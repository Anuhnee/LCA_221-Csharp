using System;
using System.Collections.Generic;

namespace CheckersProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Game game1 = new Game();

            game1.DrawBoard();

        }

    }
}
