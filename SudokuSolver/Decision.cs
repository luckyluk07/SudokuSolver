using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public enum Decision
    {
        SolveByBacktracking,
        InsertSudoku,
        PrintSudoku,
        Exit, 
        Unknown
    }
}
