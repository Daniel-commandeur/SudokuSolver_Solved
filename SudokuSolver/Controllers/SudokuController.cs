using SudokuSolver.Logics;
using SudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SudokuSolver.Controllers
{
    public class SudokuController : Controller
    {
        private Solver solver = new Solver();
        private SudokuModel sudokuModel = new SudokuModel();
        private IEnumerable<Sudoku> SudokuList = Sudokus.MockData();


        // GET: Sudoku
        public ActionResult Sudoku()
        {
            if (TempData["sudoku"] != null)
            {
                sudokuModel = TempData["sudoku"] as SudokuModel;
            }

            sudokuModel.Sudokus = SudokuList;

            if (sudokuModel.Cells == null)
            {
                sudokuModel.Cells = SudokuList.ElementAt(0).Cells;
            }

            return View(sudokuModel);
        }

        public ActionResult Solve(SudokuModel Model)
        {
            Model.Cells = solver.Solve(Model.Cells);
            TempData["sudoku"] = Model;
            return RedirectToAction("Sudoku");
        }
        
        [HttpPost]
        public ActionResult ChangeSudoku()
        {
            
            int sudokuNumber = (int)TempData["sudokunumber"];
            TempData["sudoku"] = new SudokuModel { Cells = SudokuList.ElementAt(sudokuNumber).Cells, SudokuId = sudokuNumber };
            return RedirectToAction("Sudoku");
        }

        [HttpPost]
        public ActionResult ChangeSudoku([Bind(Include ="SudokuId")]SudokuModel sudoku)
        {
            //does the sudoku model exist?
            var x = sudoku;

            return RedirectToAction("Sudoku");
        }

        public ActionResult CreateSudoku()
        {
            sudokuModel.Cells = solver.Create(SudokuList.ElementAt(2).Cells);
            TempData["sudoku"] = sudokuModel;
            return RedirectToAction("Sudoku");
        }
    }
}