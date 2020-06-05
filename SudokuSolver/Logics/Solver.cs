using SudokuSolver.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using static SudokuSolver.Logics.Board;

namespace SudokuSolver.Logics
{
    [Flags]
    public enum SolveState
    {
        Solved = 1,
        Failed = 2,
        TooManyIterations = 4 | Failed,
        NotAllowedToGuess = 8 | Failed,
        TriedEverything = 16 | Failed,
        Impossible = 32 | Failed,
        IllegalBoard = 64 | Failed,
        SolvedByGuessing = 128 | Solved,
        SolvedWithoutGuessing = 256 | Solved,
    }

    public class Solver
    {
        public bool AllowGuessing { get; set; } = true;
        public int  IterationLimit = 10000;
        private int Iterations = 0;
        public string LastState = string.Empty;

        public int[][] Solve(int[][] sudoku)
        {
            Board board = new Board();
            board.Load(sudoku);

            Iterations = 0;
            Stopwatch sw = Stopwatch.StartNew();
            SolveState s = SolveBoard(ref board); sw.Stop();
            Trace.WriteLine($"Took {sw.ElapsedMilliseconds} milliseconds, and {Iterations} iterations.");
            LastState = s.ToString();
            if ((s & SolveState.Solved) == SolveState.Solved)
            {
                Printer.PrintBoard(board);
                Trace.WriteLine($"Solved it! ({s})");
                
                return board.Unload();
            }
            Trace.WriteLine($"Failed to solve.. ({s})");  
            return sudoku;
        }

        //Recursive method
        public SolveState SolveBoard(ref Board b)
        {
            while (true)
            {
                if (Iterations > IterationLimit) return SolveState.TooManyIterations;
                ++Iterations;

                int Count = b.Iterate();

                if (b.globalSolved == size * size) return SolveState.SolvedWithoutGuessing;

                if (Count == -1) return SolveState.Impossible;

                if (Count == 0)
                {
                    if (!AllowGuessing) return SolveState.NotAllowedToGuess;

                    if (!b.GetHighestChance(out int x, out int y))  return SolveState.TriedEverything; 

                    var copy = b.Copy();
                    int guess = copy.Cells[x, y].First;
                    copy.Cells[x, y].Possible = new List<int>(new[] { guess });

                    if ((SolveBoard(ref copy) & SolveState.Solved) == SolveState.Solved)
                    {
                        b = copy.Copy();
                        return SolveState.SolvedByGuessing;
                    }
                    else
                    {
                        b.Cells[x, y].Possible.Remove(guess);
                    }
                }
            }
        }

        //Create SLOEBER CODE
        public int[][] Create(int[][] sudoku)
        {
            int randomPlaces = 2;
            int PlacesLeft = 30;
            int MaxLocalIterations = 900;
            int session = 0;

            Random rnd = new Random();
            var backup = AllowGuessing; 
            

            Board b = new Board();
            b.Load(sudoku);

            Trace.WriteLine("Creating...");
            Stopwatch sw = Stopwatch.StartNew();
            

            while (true)
            {
                session++;
                Trace.WriteLine($"Session {session}");
                b.Load(sudoku);
                AllowGuessing = true;

                while (true)
                {
                    int px = 0, py = 0;
                    Board copy = b.Copy();

                    for (int i = 0; i < randomPlaces; ++i)
                    {
                        px = rnd.Next(0, 9);
                        py = rnd.Next(0, 9);
                        copy.Cells[px, py].Possible = new List<int>() { rnd.Next(1, 10) };
                    }

                    Iterations = 0;
                    var s = SolveBoard(ref copy);

                    Iterations = 0;
                    if ((s & SolveState.Solved) == SolveState.Solved)
                    {
                        b = copy;
                        break;
                    }
                }

                AllowGuessing = false;

                //Keep removing stuff until its unsolvable
                int localItertaions = 0;
                while (true)
                {
                    if (localItertaions > MaxLocalIterations) break;
                    localItertaions++;


                    Board copy = b.Copy();

                    int xr = rnd.Next(0, 9);
                    int yr = rnd.Next(0, 9);

                    copy.Cells[xr, yr] = new Cell(0);

                    var copy2 = copy.Copy();
                    var s = SolveBoard(ref copy2);

                    if ((s & SolveState.Solved) == SolveState.Solved)
                    {
                        int left = 0;
                        b = copy;
                        b.Loop((x, y, c) => { if (c.Solved) left++; });

                        if (left <= PlacesLeft)
                        {
                            //Finished!
                            Trace.WriteLine("Finished!");
                            Trace.WriteLine($"Took {sw.ElapsedMilliseconds} milliseconds.");
                            sw.Stop();
                            AllowGuessing = backup;
                            return b.Unload();
                        }
                    }
                }
            }
        }
    }
}