using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace SudokuSolver.Logics
{
	public class Printer
	{
		public static void PrintBoard(Board b)
		{
            Trace.WriteLine('#' + new string('-', Board.size + 2) + '#');
            for (int y = 0; y < Board.size; y++)
			{
				for (int x = 0; x < Board.size; x++)
				{
                    if (x % 3 == 0) Trace.Write("|");

                    if (b.Cells[x, y].Solved)
                        Trace.Write(b.Cells[x, y].First);
                    else
                        Trace.Write("0");
				}
				Trace.WriteLine("|");
                if ((y+1) % 3 == 0) Trace.WriteLine('#'+new string('-',Board.size + 2)+'#');
			}
		}
	}
}