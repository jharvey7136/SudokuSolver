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
    public partial class SudokuForm : Form
    {
        string[,] puzzle = new string[9, 9];

        public SudokuForm()
        {
            InitializeComponent();
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void orig1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            
            var cells = GetAll(this, typeof(TextBox));
            //MessageBox.Show("Total Controls: " + c.Count());
            int i = 1;

            for (int r = 0; r < 9; r++)      //iterate through rows
            {
                for (int c = 0; c < 9; c++)  //iterate through columns
                {
                    foreach (Control cell in cells)
                    {
                        if (cell.Name == "orig" + i)
                        {
                            puzzle[r, c] = cell.Text;
                            break;
                        }
                    }
                    i++;
                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            int row, column;

            row = Int32.Parse(textBox1.Text);
            column = Int32.Parse(textBox2.Text);

            label1.Text = puzzle[row, column];
        }
    }
}
