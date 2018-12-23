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
        //SudokuForm form = new SudokuForm();

        public MySolver()
        {
            
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }


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




    }
}
