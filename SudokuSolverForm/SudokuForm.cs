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
        MySolver solver = new MySolver();

        public SudokuForm()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void orig1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (solver.LoadPuzzle(puzzle, this) < 1)
                MessageBox.Show("Error loading puzzle!");
            else MessageBox.Show("Puzzle loaded!");
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
