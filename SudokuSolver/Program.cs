using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] rows = { "780400120", "780400120", "780400120", "780400120", "780400120", "780400120", "780400120", "780400120", "780400120" };
            char[,] board = new char[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = rows[i][j];
                }
            }
            SudokuBoard sudoku = new SudokuBoard(board);
            sudoku.PrintBoard();
        }
    }
}
