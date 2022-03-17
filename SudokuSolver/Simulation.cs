﻿using System;
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
                    case 9:
                        return;
                    default:
                        break;
                }
            }

            return;
        }

        private void insertRowByRow()
        {
            String[] rows = new String[9];
            for (int i = 0; i < 9; i++)
            {
                rows[i] = Console.ReadLine();
                if (rows[i].Length > 9)
                {
                    Console.WriteLine($"Too long input, row: {rows[i]} has {rows[i].Length} characters\n");
                    break;
                }
            }
            this.sudokuBoard = new SudokuBoard(rows);
        }
    }
}
