using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SudokuSolver.Logics
{
    public class Cell
    {
        //Copy constructor
        public Cell(Cell l) => Possible = new List<int>(l.Possible);

        public Cell(int initial)
        {
            if (initial != 0)
                Possible = new List<int>() { initial };
        }

        public int First { get => Possible.First(); }

        public bool Solved { get => Possible.Count == 1; }

        public bool Impossible { get => Possible.Count == 0; }

        public List<int> Possible = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

        public override string ToString()
        {
            string final = string.Empty;
            final += '[';
            foreach (var i in Possible) final += $"{i},";
            final.TrimEnd(',');
            final += ']';
            return final;
        }
    }
}