﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SudokuSolver.Models
{
    public static class Sudokus
    {
        public static IEnumerable<Sudoku> MockData()
        {
            List<Sudoku> sudokuList = new List<Sudoku>
                {
                new Sudoku
                {
                    SudokuId = 0,
                    Name = "Logical",
                    Cells = new int[][]
                    {
                        new int[9] { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
                        new int[9] { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
                        new int[9] { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
                        new int[9] { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
                        new int[9] { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
                        new int[9] { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
                        new int[9] { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
                        new int[9] { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
                        new int[9] { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
                    }
                },
                new Sudoku
                {
                    SudokuId = 1,
                    Name = "Guessing",
                    Cells = new int[][]
                    {
                        new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        new int[9] { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
                        new int[9] { 8, 0, 0, 0, 6, 0, 0, 0, 0 },
                        new int[9] { 0, 0, 0, 8, 0, 0, 0, 0, 0 },
                        new int[9] { 7, 0, 0, 0, 2, 0, 0, 0, 0 },
                        new int[9] { 0, 6, 0, 0, 0, 0, 0, 0, 0 },
                        new int[9] { 0, 0, 0, 4, 1, 9, 0, 0, 0 },
                        new int[9] { 0, 0, 0, 0, 8, 0, 0, 0, 0 }
                    }
                },
                new Sudoku
                {
                    SudokuId = 2,
                    Name = "Empty",
                    Cells = new int[][]
                    {
                        new int[9],
                        new int[9],
                        new int[9],
                        new int[9],
                        new int[9],
                        new int[9],
                        new int[9],
                        new int[9],
                        new int[9]
                    }
                }
            };
            return sudokuList as IEnumerable<Sudoku>;
        }
    }
}