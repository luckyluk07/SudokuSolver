using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Validator
    {
        public Validator()
        {
        }

        public Boolean ValidateSudoku(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (!checkColumn(i, board) || !checkRow(i, board) || !checkSquare(i, board))
                {
                    return false;
                }
            }
            return true;
        }
        private Boolean checkColumn(int columnIndex, char[,] board)
        {
            HashSet<char> columnNumbers = new HashSet<char>();
            for (int y = 0; y < board.GetLength(0); y++)
            {
                if (!columnNumbers.Add(board[y, columnIndex]) && board[y, columnIndex] != '0')
                {
                    Console.WriteLine($"{board[y, columnIndex]} is repeated in {columnIndex + 1} column");
                    return false;
                }
            }
            return true;
        }

        private Boolean checkRow(int rowIndex, char[,] board)
        {
            HashSet<char> rowNumbers = new HashSet<char>();
            for (int x = 0; x < board.GetLength(0); x++)
            {
                if (!rowNumbers.Add(board[rowIndex, x]) && board[rowIndex, x] != '0')
                {
                    Console.WriteLine($"{board[rowIndex, x]} is repeated in {rowIndex + 1} row");
                    return false;
                }
            }
            return true;
        }

        private Boolean checkSquare(int squareIndex, char[,] board)
        {
            int x_diff = squareIndex % 3;
            int y_diff;
            if (squareIndex < 3)
            {
                y_diff = 0;
            }
            else if (squareIndex < 6)
            {
                y_diff = 1;
            }
            else
            {
                y_diff = 2;
            }

            HashSet<char> squareNumbers = new HashSet<char>();
            for (int i = 3 * y_diff; i < (y_diff + 1) * 3; i++)
            {
                for (int j = 3 * x_diff; j < (x_diff + 1) * 3; j++)
                {
                    if (!squareNumbers.Add(board[i, j]) && board[i, j] != '0')
                    {
                        Console.WriteLine($"{board[i, j]} is repeated in square ({y_diff + 1} on y and {x_diff + 1} on x)");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
