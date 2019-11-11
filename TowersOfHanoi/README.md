# Towers of Hanoi

### LCA 221-C# - Checkpoint 1

---
Towers of Hanoi is a  puzzle game, originally charcterized with 3 rods and a number of disks of various sizes.
The rings go on the rods from largest to smallest. 

In this C# version, rods are characterized with rows "**A**, **B**, **C**"

Rings are the numbers "**4,3,2,1,**"

Upon starting of the program, all rings will be on row **A**. 

``` 

A: 4 3 2 1  
B:
C:

```

## Objective

The main objective of the game is to get all rings, in order from largest to smallest, onto the third tower. 

## Rules
- You can only move the top number from any given tower.
- Larger numbers can NOT stack onto smaller numbers.
- Winning game only occurs if you manage to get numbers to Tower C in correct order.
 ``` 
A:
B:
C: 4 3 2 1

 ```

## Gameplay 

Upon starting program, the rules will be printed out, along with the gameboard. 
You will be prompted to select a tower to take a ring from, and and then a tower to place the ring.

``` 
Please select a tower to move from:
[Your input here] + hit enter to advance the program

Please select a tower to move to: 
[Your input here] + hit enter to advance the program
```
You can choose to capitalize your input, although it is not needed.

If you accidentally try to place a larger number on top of a smaller number, you will be halted and told to try again, for the move is an illegal one.

This will loop until you've won the game.

---

# Code Plan

 *This section will go over my plan when constructing this program, I will admit, this code plan and .md file was created after the program was considered finished.*

This assignment marked the first true test of taking apart the idea of this program and dividing the tasks and data into sections to better form an idea of how to go about building the program.

There was a hint given in the textbook about using a dictionary to hold the keys and values of the gameboard.
Where the towers were of type string and they would be the Keys, and the rings or pegs are the values of the dictionary. 

The rings or pegs are of Stack(int) type, so every time you are making a move, the MakeMove() method is taking those values from the dictionary and simply moving from one stack to another. 

Below is the list of methods used:


>- **BuildBoard()**
>- **UserInput()**
>- **MoveCheck()**
>- **MakeMove()**
>- **WinCheck()**

#### Main
Handles the initial build and of the game, introducing the title and rules, and prints the board.
The main method has a *do while* loop that calls BuildBoard(), UserInput(), and WinCheck() *while* WinGame == false
```
            do
            {
                BuildBoard();
                UserInput();
                WinCheck();
            } while (WinGame == false);
```


#### BuildBoard()
Once I had the dictionary keys and values figured out, I needed a way to display those values. 
I made this method to simply print out the towers and the rings.

```
        {
            foreach (var Tower in Gameboard)
            {
                Console.Write(Tower.Key);

                Console.WriteLine(string.Join(" ", Tower.Value.Reverse()));
            }
        }
```
#### UserInput()
This method prints out the prompt that asks the user what tower to take from and where to place the ring.
After the user gives both string values, this method calls the MoveCheck() method to check if the move is illegal or not.
```
        {
            Console.WriteLine("Select a tower to move from: ");
            string fromTower = Console.ReadLine().ToUpper();

            Console.WriteLine("Select a tower to move to: ");
            string toTower = Console.ReadLine().ToUpper();

            Console.WriteLine("\n");

            if (MoveCheck(fromTower, toTower))
            {
                MakeMove(fromTower, toTower);
            }
            else
            {
                Console.WriteLine("Sorry that is an invalid move. Try again.");
                return;
            }

```
#### MoveCheck()
This method takes in the value returned from UserInput() and runs through *if* and *else if* statements to manage logic calculations.
Determinds if the move is illegal or not, if legal call the MakeMove() method. If not, display error message and loop UserInput().
```
        {
            Stack<int> fromStack = Gameboard[fromTower];
            Stack<int> toStack = Gameboard[toTower];

            if (fromTower == toTower)
            {
                return false;
            }
            else if (fromStack.Count == 0)
            {
                return false;
            }
            else if (toStack.Count == 0)
            {
                return true;
            }
            else
            {
                int toValue = Gameboard[toTower].Peek();
                int fromValue = Gameboard[fromTower].Peek();

                if (fromValue > toValue)
                {
                    return false;
                }
                return true;
            }
        }


```
#### MakeMove()
This method handles the actual *pushing* and *popping* of the stack that holds the values for the rings. 
Is responsible for the movement of the top ring destination.
```
        {
            int fromPeg = Gameboard[fromTower].Pop();

            Gameboard[toTower].Push(fromPeg);
        }


```
#### WinCheck()
Checks the game condition. Game condition is a win whenever Tower **C** has a count of 4 in it's stack. Otherwise, WinCheck = *false*.
```
        {
            if( Cpegs.Count == 4)
            {
                Console.WriteLine("You Win!");
                WinGame = true;
            }
            else { WinGame = false; }
        }

```