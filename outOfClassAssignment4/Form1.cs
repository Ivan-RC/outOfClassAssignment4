using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Ivan Rivas
//This is my own work

namespace outOfClassAssignment4
{
    public partial class Form1 : Form
    {
        tictactoebutton[,] grid = new tictactoebutton[3, 3];
        bool xTurn = true;
        public Form1()
        {
            InitializeComponent();
            tictactoebutton t_Button = new tictactoebutton();

            //Initialize grid with buttons
            int x = 0, y = 0;
            Point loc = new Point(x, y);
            for(int row = 0; row < 3; row++)
            {
                for(int col = 0; col < 3; col++)
                {
                    grid[row, col] = new tictactoebutton();
                    this.Controls.Add(grid[row, col]);
                    grid[row, col].Location = new Point(x, y);
                    grid[row, col].Click += new EventHandler(button_Click);
                    x += 85;
                }
                y += 85;
                x = 0;
            }
        }

        private bool checkForWin()
        {
            //logic that checks for a winner
            if(grid[0,0].Text != "_")
            {
                //Check for horizontal win
                if(grid[0,0].Text == grid[0,1].Text && grid[0,1].Text == grid[0, 2].Text)
                {
                    MessageBox.Show(grid[0,0].Text + " wins!");
                    return true;
                }

                //Check for a vertical win
                if (grid[0, 0].Text == grid[1, 0].Text && grid[1, 0].Text == grid[2, 0].Text)
                {
                    MessageBox.Show(grid[0, 0].Text + " wins!");
                    return true;
                }
            }

            if(grid[1,1].Text != "_")
            {
                //Check for horizontal win
                if (grid[1, 0].Text == grid[1, 1].Text && grid[1, 1].Text == grid[1, 2].Text)
                {
                    MessageBox.Show(grid[1, 1].Text + " wins!");
                    return true;
                }
                //Check for vertical win
                if (grid[0, 1].Text == grid[1, 1].Text && grid[1, 1].Text == grid[2, 1].Text)
                {
                    MessageBox.Show(grid[0, 1].Text + " wins!");
                    return true;
                }
            }

            if(grid[2,2].Text != "_")
            {
                //Check for horizontal win
                if (grid[2, 2].Text == grid[1, 2].Text && grid[1, 2].Text == grid[0, 2].Text)
                {
                    MessageBox.Show(grid[2, 2].Text + " wins!");
                    return true;
                }

                //Check for a vertical win
                if (grid[2, 2].Text == grid[2, 1].Text && grid[2, 1].Text == grid[2, 0].Text)
                {
                    MessageBox.Show(grid[2, 2].Text + " wins!");
                    return true;
                }
            }

            //Check for diagonal win
            if(grid[0, 0].Text != "_" && (grid[0, 0].Text == grid[1, 1].Text && grid[1, 1].Text == grid[2, 2].Text))
            {
                MessageBox.Show(grid[0, 0].Text + " wins!");
                return true;
            }
            //Check for diagonal win
            if(grid[0, 2].Text != "_" && (grid[0, 2].Text == grid[1, 1].Text && grid[1, 1].Text == grid[2, 0].Text))
            {
                MessageBox.Show(grid[0, 2].Text + " wins!");
                return true;
            }

            return false;
        }

        private bool checkForDraw()
        {
            if (checkForWin()) return false;
            for(int r = 0; r < 3; r++)
            {
                for(int c = 0; c < 3; c++)
                {
                    if(grid[r, c].Text == "_")
                    {
                        return false;
                    }
                }
            }
            MessageBox.Show("It's a draw!");
            return true;
        }

        private void resetBoard()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    grid[r, c].Text = "_";
                    grid[r, c].BackColor = Color.Black;
                    grid[r, c].ForeColor = Color.Aqua;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            //capture the sender
            tictactoebutton t = (tictactoebutton)sender;
            if(t.Text != "_")
            {
                return;
            }

            if (xTurn)
            {
                t.BackColor = Color.MediumSpringGreen;
                t.ForeColor = Color.LightGoldenrodYellow;
                t.Text = "X";
            }
            else
            {
                t.BackColor = Color.MediumPurple;
                t.ForeColor = Color.PeachPuff;
                t.Text = "O";
            }
            xTurn = !xTurn;
            if(checkForWin() || checkForDraw())
            {
                resetBoard();
            }

        }
    }
}
