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
        int[,] iPuzzle = new int[9, 9];
        MySolver solver = new MySolver();

        public SudokuForm()
        {
            InitializeComponent();
            SetTestPuzzle();
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

            label1.Text = iPuzzle[row, column].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            iPuzzle = solver.ConvertToInts(puzzle);

            MessageBox.Show("Puzzle converted!");
        }

        private bool SolveSudoku(int[,] puzzle)
        {

            return false;
        }

        private void SetTestPuzzle()
        {
            orig2.Text = "2";
            orig4.Text = "6";
            orig6.Text = "8";
            orig10.Text = "5";
            orig11.Text = "8";
            orig15.Text = "9";
            orig16.Text = "7";
            orig23.Text = "4";
            orig28.Text = "3";
            orig29.Text = "7";
            orig34.Text = "5";
            orig37.Text = "6";
            orig45.Text = "4";
            orig48.Text = "8";
            orig53.Text = "1";
            orig54.Text = "3";
            orig59.Text = "2";
            orig66.Text = "9";
            orig67.Text = "8";
            orig71.Text = "3";
            orig72.Text = "6";
            orig76.Text = "3";
            orig78.Text = "6";
            orig80.Text = "9";            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void orig1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
