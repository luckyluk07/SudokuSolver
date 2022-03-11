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

        public SudokuBoard(String[] lines)
        {
            this.board = new char[lines.Length, lines[0].Length];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    board[i, j] = lines[i][j];
                }
            }
        }

        public Boolean Validate()
        {
            for (int i = 0; i < MaxNumber; i++)
            {
                if (!checkColumn(i) || !checkRow(i))
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean checkColumn(int columnIndex)
        {
            HashSet<char> columnNumbers = new HashSet<char>();
            for (int y = 0; y < MaxNumber; y++)
            {
                if (!columnNumbers.Add(board[columnIndex, y]) && board[columnIndex, y] != '0')
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean checkRow(int rowIndex)
        {
            HashSet<char> rowNumbers = new HashSet<char>();
            for (int x = 0; x < MaxNumber; x++)
            {
                if (!rowNumbers.Add(board[rowIndex,x]) && board[rowIndex, x] != '0')
                {
                    return false;
                }
            }
            return true;
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
