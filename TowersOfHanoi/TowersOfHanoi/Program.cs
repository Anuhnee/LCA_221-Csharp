using System;
using System.Collections.Generic;
using System.Linq;

namespace TowersOfHanoi
{
    internal class Program
    {
        //board
        private static Dictionary<string, Stack<int>> Gameboard = new Dictionary<string, Stack<int>>();

        //pegs
        private static Stack<int> Apegs = new Stack<int>();

        private static Stack<int> Bpegs = new Stack<int>();
        private static Stack<int> Cpegs = new Stack<int>();

        //bool variable on game condition
        private static bool WinGame = false;

        private static void Main(string[] args)
        {
            //Introductory print out of game
            Console.WriteLine("TOWERS OF HANOI\n");
            Console.WriteLine("A,B,C are towers.\nNumbers are pegs.\n");
            Console.WriteLine("---------------------------------RULES------------------------------------------");
            Console.WriteLine("1. Blocks can only be moved to be on top of larger blocks\n" +
                              "2. Only the top block from any given stack can be moved\n" +
                              "3. You win the game by moving the entire stack from the first tower to the third tower");
            Console.WriteLine("--------------------------------------------------------------------------------");

            //Initial build of gameboard 
            Apegs.Push(4);
            Apegs.Push(3);
            Apegs.Push(2);
            Apegs.Push(1);

            Gameboard.Add("A", Apegs);
            Gameboard.Add("B", Bpegs);
            Gameboard.Add("C", Cpegs);

            //Main game loop
            do
            {
                BuildBoard();
                UserInput();
                WinCheck();
            } while (WinGame == false);
        }

        #region BuildBoard

        public static void BuildBoard()
        {
            //loops through Gameboard and displays Stack Keys and Values
            foreach (var Tower in Gameboard)
            {
                Console.Write(Tower.Key);

                Console.WriteLine(string.Join(" ", Tower.Value.Reverse()));
            }
        }

        #endregion BuildBoard

        #region UserInput

        public static void UserInput()
        {
            //prompts user to select tower to take from
            Console.WriteLine("Select a tower to move from: ");
            string fromTower = Console.ReadLine().ToUpper();

            //prompts user to select tower to move to
            Console.WriteLine("Select a tower to move to: ");
            string toTower = Console.ReadLine().ToUpper();

            Console.WriteLine("\n");

            //runs MoveCheck method, perform MakeMove() method if return true
            if (MoveCheck(fromTower, toTower))
            {
                MakeMove(fromTower, toTower);
            }
            else
            {
                //Prompts user invalid move message if return is false
                Console.WriteLine("Sorry that is an invalid move. Try again.");
                return;
            }
        }

        #endregion UserInput

        #region MoveCheck

        public static bool MoveCheck(string fromTower, string toTower)
        {
            //new stack<int> variable taken from user input
            Stack<int> fromStack = Gameboard[fromTower];
            Stack<int> toStack = Gameboard[toTower];

            //if user input equal each other, illegal move
            if (fromTower == toTower)
            {
                return false;
            }
            //if user input targets empty stack to take from, illegal move
            else if (fromStack.Count == 0)
            {
                return false;
            }
            //if user input targets an empty stack to move to, legal move
            else if (toStack.Count == 0)
            {
                return true;
            }
            else
            {
                //int variables derived from the top number of the stacks being selected
                int toValue = Gameboard[toTower].Peek();
                int fromValue = Gameboard[fromTower].Peek();

                //if the top number of the fromTower is greater than the top number in the toTower then illegal move
                if (fromValue > toValue)
                {
                    return false;
                }
                //otherwise, it's legal
                return true;
            }
        }

        #endregion MoveCheck

        #region MakeMove

        public static void MakeMove(string fromTower, string toTower)
        {
            //int variable derived from the popped number from the fromTower
            int fromPeg = Gameboard[fromTower].Pop();

            //pushes the popped number to the toTower destination
            Gameboard[toTower].Push(fromPeg);
        }

        #endregion MakeMove

        #region Wincheck
        public static void WinCheck()
        {
            //if C Tower has a count of 4 then user wins
            if( Cpegs.Count == 4)
            {
                Console.WriteLine("You Win!");
                WinGame = true;
            }
            //otherwise, game has not been won yet
            else { WinGame = false; }
        }
        #endregion
    }
}