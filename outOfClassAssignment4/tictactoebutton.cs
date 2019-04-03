using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace outOfClassAssignment4
{
    class tictactoebutton : Button
    {
        public static int btn_Size = 85;
        public tictactoebutton()
        {
            this.Width = this.Height = btn_Size;
            this.BackColor = System.Drawing.Color.Black;
            this.FlatStyle = FlatStyle.Flat;
            this.Text = "_";
            this.ForeColor = System.Drawing.Color.Aqua;
            this.Font = new System.Drawing.Font("Consolas", 20);
        }
    }
}
