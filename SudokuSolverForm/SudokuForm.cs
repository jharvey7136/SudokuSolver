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


            int i = 1;
            int[,] puzzle = new int[9, 9];

            var cells = GetAll(this, typeof(TextBox));
            //MessageBox.Show("Total Controls: " + c.Count());

            for (int n = 1; n < 82; n++)
            {
                foreach (Control c in cells)
                {
                    if(c.Name == "orig" + i)
                    {
                        c.Text = i.ToString();
                        i++;
                    }                        
                }
            }

        }

        private void orig1_TextChanged(object sender, EventArgs e)
        {

        }




    }
}
