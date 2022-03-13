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
                if (!checkColumn(i) || !checkRow(i) || !checkSquare(i))
                {
                    return false;
                }
            }
            return true;
        }

        public Boolean SolveByBacktracking()
        {
            if (findEmptyPlaces() == null)
            {
                return true;
            }
            var emptyPlace = findEmptyPlaces();
            int y = emptyPlace.Item1;
            int x = emptyPlace.Item2;
            for (int i = '1'; i <= '9'; i++)
            {
                char number = (char)i;
                if (board[y, x] == '0' && checkPotentialPlace(number, x, y))
                {
                    board[y, x] = number;
                    if(SolveByBacktracking())
                    {
                        return true;
                    }

                    board[y, x] = '0';
                }
            }
            return false;
        }

        private Boolean checkIsSolved()
        {
            for (int i = 0; i < MaxNumber; i++)
            {
                for (int j = 0; j < MaxNumber; j++)
                {
                    if (board[i,j] == '0')
                    {
                        return false;
                    }
                }
            }
            return Validate();
        }

        private Tuple<int,int> findEmptyPlaces()
        {
            for (int i = 0; i < MaxNumber; i++)
            {
                for (int j = 0; j < MaxNumber; j++)
                {
                    if (board[i, j] == '0')
                    {
                        return Tuple.Create(i, j);
                    }
                }
            }
            return null;
        }

        private Boolean checkPotentialPlace(char number, int x, int y)
        {
            if (board[y, x] != '0')
            {
                //Console.WriteLine("This place is already filled");
                return false;
            }
            //check column
            for (int i = 0; i < MaxNumber; i++)
            {
                if (board[i, x] == number && i != y)
                {
                    return false;
                }
            }

            //check row
            for (int i = 0; i < MaxNumber; i++)
            {
                if (board[y,i] == number && i != x)
                {
                    return false;
                }
            }

            int square_x = x / 3;
            int square_y = y / 3;
            //check sqare
            for (int i = square_y * 3; i < square_y * 3 + 3; i++)
            {
                for (int j = square_x * 3; j < square_x * 3 + 3; j++)
                {
                    if (board[i,j] == number && i != y && j != x)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private Boolean checkColumn(int columnIndex)
        {
            HashSet<char> columnNumbers = new HashSet<char>();
            for (int y = 0; y < MaxNumber; y++)
            {
                if (!columnNumbers.Add(board[y, columnIndex]) && board[y, columnIndex] != '0')
                {
                    Console.WriteLine($"{board[y, columnIndex]} is repeated in {columnIndex + 1} column");
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
                    Console.WriteLine($"{board[rowIndex, x]} is repeated in {rowIndex + 1} row");
                    return false;
                }
            }
            return true;
        }

        private Boolean checkSquare(int squareIndex)
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
                    if(!squareNumbers.Add(board[i,j]) && board[i, j] != '0')
                    {
                        Console.WriteLine($"{board[i, j]} is repeated in square ({y_diff + 1} on y and {x_diff + 1} on x)");
                        return false;
                    }
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
