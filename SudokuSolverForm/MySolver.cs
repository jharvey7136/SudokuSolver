using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolverForm
{
    class MySolver
    {
        //string[,] myPuzzle = new string[9, 9];
        //public SudokuForm myForm;

        public MySolver()
        {
            //this.myForm = form;
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        /*---------------------- function to read and load all inputs in the cells ----------------------*/
        public int LoadPuzzle(string[,] puzzle, SudokuForm form)
        {
            var cells = GetAll(form, typeof(TextBox));
            //MessageBox.Show("Total Controls: " + c.Count());
            int i = 1;

            for (int r = 0; r < 9; r++)      //iterate through rows
            {
                for (int c = 0; c < 9; c++)  //iterate through columns
                {
                    foreach (Control cell in cells) //iterate through all textbox cells
                    {
                        if (cell.Name == "orig" + i)    //if textbox name matches, add number to puzzle array
                        {
                            puzzle[r, c] = cell.Text;
                            break;
                        }
                    }
                    i++;
                }
            }
            return 1;
        }

        /*---------------------- converts the strings in the textboxes to ints ----------------------*/
        public int[,] ConvertToInts(string[,] puzzle)
        {
            int x;
            int[,] intPuzzle = new int[9, 9];
            for (int r = 0; r < 9; r++)      //iterate through rows
            {
                for (int c = 0; c < 9; c++)  //iterate through columns
                {        
                    if (Int32.TryParse(puzzle[r,c], out x))
                    {
                        intPuzzle[r, c] = x;
                    }                    
                }
            }
            return intPuzzle;
        }


        /*---------------------- function to recursively test each cell with valid numbers 1-9 ----------------------*/
        public bool SolveHelper(int[,] puzzle, int row, int column)
        {
            int number = 1;

            //test if already advanced through the puzzle
            if (row == 9) return true;

            //test if cell is already set
            if (puzzle[row, column] > 0)            //need to test this
            {
                if (column == 8)
                {
                    if (SolveHelper(puzzle, row + 1, 0)) return true;
                }
                else
                {
                    if (SolveHelper(puzzle, row, column + 1)) return true;
                }
                return false;
            }

            for (; number < 10; number++)
            {
                if (IsValid(number, puzzle, row, column))
                {
                    puzzle[row,column] = number;
                    if (column == 8)
                    {
                        if (SolveHelper(puzzle, row + 1, 0)) return true;
                    }
                    else
                    {
                        if (SolveHelper(puzzle, row, column + 1)) return true;
                    }
                    puzzle[row,column] = 0;
                }
            }

            return false;
        }

        /*---------------------- function to test if number is valid in the given cell ----------------------*/
        public bool IsValid(int number, int[,] puzzle, int row, int column)
        {
            int i = 0;
            int modRow = 3 * (row / 3);
            int modCol = 3 * (column / 3);
            int row1 = (row + 2) % 3;
            int row2 = (row + 4) % 3;
            int col1 = (column + 2) % 3;
            int col2 = (column + 4) % 3;

            for (i = 0; i < 9; i++)
            {
                if (puzzle[i, column] == number) return false;
                if (puzzle[row,i] == number) return false;
            }

            if (puzzle[(row1 + modRow), (col1 + modCol)] == number) return false;
            if (puzzle[(row2 + modRow), (col1 + modCol)] == number) return false;
            if (puzzle[(row1 + modRow), (col2 + modCol)] == number) return false;
            if (puzzle[(row2 + modRow), (col2 + modCol)] == number) return false;

            return true;
        }


    }
}
