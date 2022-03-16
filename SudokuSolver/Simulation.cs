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
                int userChoose = Console.Read() - '0';
                if (Enum.IsDefined(typeof(Decision), userChoose))
                {
                    switch(userChoose)
                    {
                        case (int)Decision.SolveByBacktracking:
                            sudokuBoard.SolveByBacktracking();
                            sudokuBoard.PrintBoard();
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
    }
}
