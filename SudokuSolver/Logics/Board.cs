using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace SudokuSolver.Logics
{

    public class Board
    {
        public delegate void Iterator(int x, int y, Cell c);

        public const int size = 9;
        public Cell[,] Cells { get; private set; } = new Cell[size, size];
        public int globalSolved = 0; //Only use after iteration

        public void Loop(Iterator i)
        {
            for (int y = 0; y < size; ++y)
                for (int x = 0; x < size; ++x)
                    i(x, y, Cells[x, y]);
        }

        public bool GetHighestChance(out int x, out int y)
        {
            int highestChance = int.MaxValue; //Lower == better
            int bx = -1, by = -1;

            for (int iy = 0; iy < size; ++iy)
            {
                for (int ix = 0; ix < size; ++ix)
                {
                    if (Cells[ix, iy].Impossible)
                    {
                        x = -1; y = -1;
                        return false;
                    }

                    if (!Cells[ix, iy].Solved && Cells[ix, iy].Possible.Count < highestChance)
                    {
                        bx = ix; by = iy;
                    }
                }
            }
            x = bx; y = by;
            return true;
        }

        //Iterate one generation
        public int Iterate()
        {
            globalSolved = 0;
            int solved = 0;
            for (int y = 0; y < size; ++y)
            {
                for (int x = 0; x < size; ++x)
                {
                    var cell = Cells[x, y];
                    if (!cell.Solved)
                    {
                        foreach (var i in GetSolvedNeighbors(x, y))
                        {
                            if (cell.Possible.Contains(i)) cell.Possible.Remove(i);
                        }
                        if (cell.Impossible) return -1;
                        if (cell.Solved) solved++;
                    }
                    if (cell.Solved) globalSolved++;
                }
            }
            return solved;
        }

        //Get x and y numbers and the Neighbors 
        public int[] GetSolvedNeighbors(int x, int y)
        {
            List<int> Neighbors = new List<int>();

            for (int i = 0; i < size; ++i)
            {
                if (Cells[x, i].Solved && i != y) Neighbors.Add(Cells[x, i].First);
                if (Cells[i, y].Solved && i != x) Neighbors.Add(Cells[i, y].First);
            }

            int xp = (int)(x / 3.0f + 1) * 3 - 3;
            int yp = (int)(y / 3.0f + 1) * 3 - 3;

            for (int iy = 0; iy < 3; ++iy)
                for (int ix = 0; ix < 3; ++ix)
                    if (ix + xp != x && yp + iy != y)
                        if (Cells[ix + xp, iy + yp].Solved) Neighbors.Add(Cells[ix + xp, iy + yp].First);

            return Neighbors.ToArray();
        }

        //Shallow Copy
        public Board Copy()
        {
            var b = new Board();
            Loop((x, y, c) => { b.Cells[x, y] = new Cell(c); });
            return b;
        }

        //Load the Sudoku
        public void Load(int[][] sudoku)
        {
            Loop((x, y, c) => { Cells[x, y] = new Cell(sudoku[y][x]); });
        }

        //Unload the Sudoku
        public int[][] Unload()
        {
            int[][] sudoku = new int[size][];
            for (int i = 0; i < size; ++i) sudoku[i] = new int[size];

            Loop((x, y, c) =>
            {
                sudoku[y][x] = 0;
                if (Cells[x, y].Solved) sudoku[y][x] = Cells[x, y].First;
            });

            return sudoku;
        }
    }
}