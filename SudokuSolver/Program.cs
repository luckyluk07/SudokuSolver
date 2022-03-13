using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] example = { "780400120", "780400120", "780400120", "780400120", "780400120", "780400120", "780400120", "780400120", "780400120" };
            String[] properExample = { "957613284", "483257196", "612849537", "178364952", "524971368", "369528741", "845792613", "291436875", "736185429" };
            String[] wrongColumns = { "957613284", "483257196", "612849537", "178364952", "524971368", "369528741", "845792613", "291436875", "736185429" };
            String[] wrongRows = { "957613284", "483257196", "612849537", "178364955", "524971368", "369528741", "845792613", "291436875", "736185429" };
            String[] exampleForBacktracking = { "780400120", "600075009", "000601078", "007040260", "001050930", "904060005", "070300012", "120007400", "049206007" };
            SudokuBoard sudoku = new SudokuBoard(exampleForBacktracking);
            Console.WriteLine(sudoku.SolveByBacktracking());
            sudoku.PrintBoard();
            Console.WriteLine(sudoku.Validate());
        }
    }
}
