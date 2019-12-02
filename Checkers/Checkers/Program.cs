using System;
using System.Collections.Generic;

namespace CheckersProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Game NewGame = new Game();

            NewGame.Start();
            Console.ReadLine();

        }

    }
}
