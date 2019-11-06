using System;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    internal class Program
    {
        //board
        static Dictionary<string, Stack<int>> Gameboard = new Dictionary<string, Stack<int>>();
        

        //pegs
        static Stack<int> Apegs = new Stack<int>();
        static Stack<int> Bpegs = new Stack<int>();
        static Stack<int> Cpegs = new Stack<int>();
        

        static void BuildBoard()
        {
            Gameboard.Add("A:", new Stack<int>(){ });
            Gameboard.Add("B:", Bpegs);
            Gameboard.Add("C:", Cpegs);

            Apegs.Push(1);
            Apegs.Push(2);
            Apegs.Push(3);
            Apegs.Push(4);

           

            //for (int i =0; Apegs.Count < 4; i++)
            //{
            //    Apegs.Push();
            //    Console.WriteLine(i);
            //}

            foreach (string Tower in Gameboard.Keys)
            {

                Console.WriteLine(Tower);
                

            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("TOWERS OF HANOI");
            BuildBoard();
            
        }
    }
}