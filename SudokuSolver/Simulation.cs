using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Simulation
    {
        private Menu menu { get; set; }
        private SudokuBoard sudokuBoard { get; set; }

        public Simulation()
        {
            menu = new Menu();
        }

        public Simulation(SudokuBoard sudoku)
        {
            this.menu = new Menu();
            this.sudokuBoard = sudoku;
        }

        public void Run()
        {
            Boolean isEnd = false;
            do
            {
                this.menu.ShowMenu();
                String tmp = Console.ReadLine();
                int userChoose = -1;
                Boolean correctConversion = true;
                if (!int.TryParse(tmp, out userChoose)) 
                {
                    correctConversion = false;
                }

                if (correctConversion && Enum.IsDefined(typeof(Decision), userChoose))
                {
                    switch(userChoose)
                    {
                        case (int)Decision.SolveByBacktracking:
                            sudokuBoard.SolveByBacktracking();
                            sudokuBoard.PrintBoard();
                            break;
                        case (int)Decision.InsertSudoku:
                            insertSudoku();
                            break;
                        case (int)Decision.PrintSudoku:
                            if (this.sudokuBoard == null)
                            {
                                Console.WriteLine("Sudoku is not initialized");
                                break;
                            }
                            this.sudokuBoard.PrintBoard();
                            break;
                        case (int)Decision.Exit:
                            isEnd = true;
                            break;
                        default:
                            break;
                    }
                }
                
            } while (!isEnd);
        }

        private void insertSudoku()
        {
            Boolean isEnd = false;
            while (!isEnd)
            {
                this.menu.ShowInsertSudokuOptions();

                String userInput = Console.ReadLine();
                int userDecision;
                if (!int.TryParse(userInput, out userDecision))
                {
                    continue;
                }

                switch (userDecision)
                {
                    case 0:
                        this.insertRowByRow();
                        break;
                    case 1:
                        this.insertColumnByColumn();
                        break;
                    case 2:
                        this.insertPointByPoint();
                        break;
                    case 9:
                        return;
                    default:
                        break;
                }
            }

            return;
        }

        private void insertPointByPoint()
        {
            char[,] board = new char[9, 9];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = '0';
                }
            }

            Console.WriteLine("Start inserting points...");
            while (true)
            {
                Console.WriteLine("Type 'e' to finish inserting points..");
                Console.Write("Type row: ");
                string input = Console.ReadLine();
                if (input == "e")
                {
                    break;
                }
                int row = int.Parse(input);

                Console.Write("Type column: ");
                input = Console.ReadLine();
                if (input == "e")
                {
                    break;
                }
                int column = int.Parse(input);

                Console.Write("Type number to enter: ");
                input = Console.ReadLine();
                if (input == "e")
                {
                    break;
                }
                int number = int.Parse(input);
                if (number < 1 || number > 9)
                {
                    Console.WriteLine("Number must not be smaller than 1 or bigger than 9");
                    continue;
                }
                board[row - 1, column - 1] = (char) (number + '0');
                printCurrentBoard(board);
            }
            this.sudokuBoard = new SudokuBoard(board);
        }

        private void insertRowByRow()
        {
            Console.WriteLine("Start inserting rows...");
            String[] rows = new String[9];
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine($"Write {i+1} line...");
                rows[i] = Console.ReadLine();
                if (rows[i].Length > 9)
                {
                    Console.WriteLine($"Too long input, row: {rows[i]} has {rows[i].Length} characters\n");
                    break;
                }
            }
            this.sudokuBoard = new SudokuBoard(rows);
        }

        private void insertColumnByColumn()
        {
            Console.WriteLine("Start inserting columns...");
            String[] columns = new String[9];
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine($"Write {i + 1} column...");
                columns[i] = Console.ReadLine();
                if (columns[i].Length > 9)
                {
                    Console.WriteLine($"Too long input, column: {columns[i]} has {columns[i].Length} characters\n");
                    break;
                }
            }
            this.sudokuBoard = new SudokuBoard(columns, true);
        }

        private static void printCurrentBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (i != 0 && i % 3 == 0)
                {
                    Console.WriteLine("---------------------");
                }

                for (int j = 0; j < board.GetLength(1); j++)
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
