using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class BacktrackingSolver
    {

        public Boolean SolveByBacktracking(char[,] board)
        {
            if (findEmptyPlaces(board) == null)
            {
                return true;
            }
            var emptyPlace = findEmptyPlaces(board);
            int y = emptyPlace.Item1;
            int x = emptyPlace.Item2;
            for (int i = '1'; i <= '9'; i++)
            {
                char number = (char)i;
                if (board[y, x] == '0' && checkPotentialPlace(board, number, x, y))
                {
                    board[y, x] = number;
                    if (SolveByBacktracking(board))
                    {
                        return true;
                    }

                    board[y, x] = '0';
                }
            }
            return false;
        }

        private Boolean checkIsSolved(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if (board[i, j] == '0')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private Tuple<int, int> findEmptyPlaces(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if (board[i, j] == '0')
                    {
                        return Tuple.Create(i, j);
                    }
                }
            }
            return null;
        }

        private Boolean checkPotentialPlace(char[,] board, char number, int x, int y)
        {
            if (board[y, x] != '0')
            {
                //Console.WriteLine("This place is already filled");
                return false;
            }
            //check column
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, x] == number && i != y)
                {
                    return false;
                }
            }

            //check row
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[y, i] == number && i != x)
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
                    if (board[i, j] == number && i != y && j != x)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
