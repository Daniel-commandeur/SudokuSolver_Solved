using System;
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
                    Name = "Solve Logical",
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
                    Name = "Solve Guessing",
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
                    Name = "Solve Empty",
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

//            }
//            SudokuModel sudoku = new SudokuModel
//            {
//                Cells = new int[9][]
//            };
//            switch (number)
//            {
//                case 1:
//                    sudoku.Cells[0] = new int[9] { 5, 3, 0, 0, 7, 0, 0, 0, 0 };
//                    sudoku.Cells[1] = new int[9] { 6, 0, 0, 1, 9, 5, 0, 0, 0 };
//                    sudoku.Cells[2] = new int[9] { 0, 9, 8, 0, 0, 0, 0, 6, 0 };
//                    sudoku.Cells[3] = new int[9] { 8, 0, 0, 0, 6, 0, 0, 0, 3 };
//                    sudoku.Cells[4] = new int[9] { 4, 0, 0, 8, 0, 3, 0, 0, 1 };
//                    sudoku.Cells[5] = new int[9] { 7, 0, 0, 0, 2, 0, 0, 0, 6 };
//                    sudoku.Cells[6] = new int[9] { 0, 6, 0, 0, 0, 0, 2, 8, 0 };
//                    sudoku.Cells[7] = new int[9] { 0, 0, 0, 4, 1, 9, 0, 0, 5 };
//                    sudoku.Cells[8] = new int[9] { 0, 0, 0, 0, 8, 0, 0, 7, 9 };
//                    break;

//                case 2:
//                    sudoku.Cells[0] = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
//                    sudoku.Cells[1] = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
//                    sudoku.Cells[2] = new int[9] { 0, 9, 8, 0, 0, 0, 0, 6, 0 };
//                    sudoku.Cells[3] = new int[9] { 8, 0, 0, 0, 6, 0, 0, 0, 0 };
//                    sudoku.Cells[4] = new int[9] { 0, 0, 0, 8, 0, 0, 0, 0, 0 };
//                    sudoku.Cells[5] = new int[9] { 7, 0, 0, 0, 2, 0, 0, 0, 0 };
//                    sudoku.Cells[6] = new int[9] { 0, 6, 0, 0, 0, 0, 0, 0, 0 };
//                    sudoku.Cells[7] = new int[9] { 0, 0, 0, 4, 1, 9, 0, 0, 0 };
//                    sudoku.Cells[8] = new int[9] { 0, 0, 0, 0, 8, 0, 0, 0, 0 };
//                    break;

//                case 3:
//                    sudoku.Cells[0] = new int[9];
//                    sudoku.Cells[1] = new int[9];
//                    sudoku.Cells[2] = new int[9];
//                    sudoku.Cells[3] = new int[9];
//                    sudoku.Cells[4] = new int[9];
//                    sudoku.Cells[5] = new int[9];
//                    sudoku.Cells[6] = new int[9];
//                    sudoku.Cells[7] = new int[9];
//                    sudoku.Cells[8] = new int[9];
//                    break;

//                default:
//                    break;
//            }

//            return sudoku;
//        }
//    }
//}