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
        int[][] originalNumbers = new int[40][];
        int origCount;
        MySolver solver = new MySolver();

        public SudokuForm()
        {
            InitializeComponent();
            SetTestPuzzle();
        }       
        
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (solver.LoadPuzzle(puzzle, this, originalNumbers) < 1)
            {
                labelStatus.Text = "Error loading puzzle!";
            }
            else
            {
                try
                {
                    iPuzzle = solver.ConvertToInts(puzzle);
                    labelStatus.Text = "Puzzle loaded!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error converting to ints: " + ex);
                }
            }            
        }


        private void buttonSolve_Click(object sender, EventArgs e)
        {
            if (SolveSudoku(iPuzzle))
            {
                PrintPuzzle(iPuzzle);
                labelStatus.Text = "Puzzle solved!";
            } else
            {
                labelStatus.Text = "No solution!";
            }
        }

        private bool SolveSudoku(int[,] puzzle)
        {
            return solver.SolveHelper(iPuzzle, 0, 0);
        }

        private void PrintPuzzle(int[,] puzzle)
        {
            var cells = solver.GetAll(this, typeof(TextBox));
            int i = 1;
            origCount = solver.GetCount();
            for(int r=0; r<9; r++)
            {
                for(int c=0; c<9; c++)
                {
                    foreach (Control cell in cells) //iterate through all textbox cells
                    {
                        if (cell.Name == "solved" + i)    //if textbox name matches, add number to solved puzzle array
                        {
                            for(int m=0; m < origCount; m++)
                            {
                                int[] temp;
                                temp = originalNumbers[m];
                                if(temp[0] == r && temp[1] == c)
                                {
                                    cell.Text = puzzle[r, c].ToString();                                    
                                }
                            }
                            if (cell.Text == "")
                            {
                                cell.Text = puzzle[r, c].ToString();
                                cell.ForeColor = System.Drawing.Color.Red;
                            }                                                        
                            break;
                        }
                    }                    
                    i++;
                }
            }
        }

        private void StoreOriginalNumbers(int[,] puzzle)
        {
            
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
