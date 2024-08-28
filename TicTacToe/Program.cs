using  System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

string[]  grid  = new string[9] {"1", "2",  "3", "4", "5",  "6", "7", "8", "9"};
bool isPlayerTurn = true;
int numTurns = 0;

while(!CheckVictory() && numTurns != 9)
{
    PrintGrid();

    if(isPlayerTurn)
       Console.WriteLine("Player 1 turn!");
    else
       Console.WriteLine("Player 2  turn!");

       string choice = Console.ReadLine();

       if(grid.Contains(choice) && choice !=  "X" && choice != "O")
       {
        int gridIndex  = Convert.ToInt32(choice) - 1;

        if(isPlayerTurn)
           grid[gridIndex] = "X";
        else
           grid[gridIndex] = "O";

           numTurns++;   
       }

       isPlayerTurn = !isPlayerTurn;

}

if(CheckVictory())
   Console.WriteLine("You win!");
else
   Console.WriteLine("Tie!");   

bool CheckVictory()
{
    bool row1 = grid[0] == grid[1] && grid[1] == grid[2];
    bool row2 = grid[3] == grid[4] && grid[4] == grid[5];
    bool row3 = grid[6] == grid[7] && grid[7] == grid[8];
    bool col1 = grid[0] == grid[3] && grid[3] == grid[6];
    bool col2 = grid[1] == grid[4] && grid[4] == grid[7];
    bool col3 = grid[2] == grid[5] && grid[5] == grid[8];
    bool diagDown = grid[0] == grid[4] && grid[4] == grid[8];
    bool diagUp = grid[6] == grid[4] && grid[4] == grid[2];

    return row1 || row2 || row3 || col1 || col2 || col3 || diagDown || diagUp;

}


void PrintGrid()
{
    for(int i = 0; i < 3; i++)
    {
        for (int  j = 0; j < 3; j++)
        {
            Console.WriteLine(grid[i * 3 +  j] + "|");
        }
        Console.WriteLine();
       if (i < 2)
       {
        Console.WriteLine("-----------");
       }
    }
}

// using System;

// class Program
// {
//     static char[,] grid = new char[3, 3];
//     static char currentPlayer = 'X';

//     static void Main(string[] args)
//     {
//         InitializeGrid();
//         PrintGrid();

//         while (true)
//         {
//             MakeMove();
//             PrintGrid();
//             if (CheckForWin())
//             {
//                 Console.WriteLine($"Player {currentPlayer} wins!");
//                 break;
//             }
//             if (CheckForDraw())
//             {
//                 Console.WriteLine("It's a draw!");
//                 break;
//             }
//             SwitchPlayer();
//         }
//     }

//     static void InitializeGrid()
//     {
//         for (int i = 0; i < 3; i++)
//         {
//             for (int j = 0; j < 3; j++)
//             {
//                 grid[i, j] = '-';
//             }
//         }
//     }

//     static void PrintGrid()
//     {
//         for (int i = 0; i < 3; i++)
//         {
//             for (int j = 0; j < 3; j++)
//             {
//                 Console.Write(grid[i, j] + " | ");
//             }
//             Console.WriteLine();
//             if (i < 2)
//             {
//                 Console.WriteLine("---------");
//             }
//         }
//     }

//     static void MakeMove()
//     {
//         Console.WriteLine($"Player {currentPlayer}, enter your move (row and column, 0-2):");
//         int row = int.Parse(Console.ReadLine());
//         int col = int.Parse(Console.ReadLine());
//         if (grid[row, col] != '-')
//         {
//             Console.WriteLine("Invalid move, try again.");
//             MakeMove();
//         }
//         else
//         {
//             grid[row, col] = currentPlayer;
//         }
//     }

//     static bool CheckForWin()
//     {
//         // Check rows
//         for (int i = 0; i < 3; i++)
//         {
//             if (grid[i, 0] == currentPlayer && grid[i, 1] == currentPlayer && grid[i, 2] == currentPlayer)
//             {
//                 return true;
//             }
//         }
//         // Check columns
//         for (int i = 0; i < 3; i++)
//         {
//             if (grid[0, i] == currentPlayer && grid[1, i] == currentPlayer && grid[2, i] == currentPlayer)
//             {
//                 return true;
//             }
//         }
//         // Check diagonals
//         if ((grid[0, 0] == currentPlayer && grid[1, 1] == currentPlayer && grid[2, 2] == currentPlayer) ||
//             (grid[0, 2] == currentPlayer && grid[1, 1] == currentPlayer && grid[2, 0] == currentPlayer))
//         {
//             return true;
//         }
//         return false;
//     }

//     static bool CheckForDraw()
//     {
//         for (int i = 0; i < 3; i++)
//         {
//             for (int j = 0; j < 3; j++)
//             {
//                 if (grid[i, j] == '-')
//                 {
//                     return false;
//                 }
//             }
//         }
//         return true;
//     }

//     static void SwitchPlayer()
//     {
//         currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
//     }
// }