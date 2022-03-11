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

        public SudokuBoard()
        {
            this.board = new char[MaxNumber, MaxNumber];
        }

        public SudokuBoard(char[,] board)
        {
            this.board = board;
        }

        public void PrintBoard()
        {
            Console.WriteLine("Current Sudoku!\n");
            for (int i = 0; i < MaxNumber; i++)
            {
                if (i != 0 && i % 3 == 0)
                {
                    Console.WriteLine("---------------------");
                }

                for (int j = 0; j < MaxNumber; j++)
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
