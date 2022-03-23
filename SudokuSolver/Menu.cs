using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Menu
    {

        public void ShowMenu()
        {
            Console.WriteLine("**********SUDOKU-SOLVER-CONSOLE-APPLICATION**********");
            Console.WriteLine("0) Solve current sudoku by backtracking");
            Console.WriteLine("1) Insert your own sudoku board");
            Console.WriteLine("2) Print out your sudoku");
            Console.WriteLine("3) EXIT");
        }

        public void ShowInsertSudokuOptions()
        {
            Console.WriteLine("*****INSERT-SUDOKU*****");
            Console.WriteLine("0) Insert line by line");
            Console.WriteLine("1) Insert column by column");
            Console.WriteLine("9) Go back to main menu");
        }
    }
}
