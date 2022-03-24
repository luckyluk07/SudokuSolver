using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class SudokuBoard
    {
        public const int MaxNumber = 9;
        private char[,] board { get; set; }
        private Validator validator { get; set; }
        private BacktrackingSolver backtrackingSolver { get; set; }

        public SudokuBoard()
        {
            this.board = new char[MaxNumber, MaxNumber];
            this.validator = new Validator();
            this.backtrackingSolver = new BacktrackingSolver();
        }

        public SudokuBoard(char[,] board)
        {
            this.board = board;
            this.validator = new Validator();
            this.backtrackingSolver = new BacktrackingSolver();
        }

        public SudokuBoard(String[] lines)
        {
            this.validator = new Validator();
            this.backtrackingSolver = new BacktrackingSolver();
            this.board = new char[lines.Length, lines[0].Length];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    board[i, j] = lines[i][j];
                }
            }
        }

        public SudokuBoard(String[] columns, bool insertColumns)
        {
            if (insertColumns)
            {
                this.validator = new Validator();
                this.backtrackingSolver = new BacktrackingSolver();
                this.board = new char[columns.Length, columns[0].Length];
                for (int i = 0; i < columns.Length; i++)
                {
                    for (int j = 0; j < columns[0].Length; j++)
                    {
                        board[j, i] = columns[i][j];
                    }
                }

            }
        }

        public Boolean Validate()
        {
            return this.validator.ValidateSudoku(this.board);
        }

        public Boolean SolveByBacktracking()
        {
            return this.backtrackingSolver.SolveByBacktracking(board);
        }

        public void PrintBoard()
        {
            Console.WriteLine("Current Sudoku!\n");
            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                if (i != 0 && i % 3 == 0)
                {
                    Console.WriteLine("---------------------");
                }

                for (int j = 0; j < this.board.GetLength(1); j++)
                {
                    if (j != 0 && j % 3 == 0)
                    {
                        Console.Write("| ");
                    }
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
