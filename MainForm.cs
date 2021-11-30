using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maxwell_Wheel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Width - this.panel1.Location.X == 50)
            {
                this.panel1.Left = this.Width - this.Width / 4;
                this.panel1.Size = new Size(this.Width / 4, this.Height);
                this.button1.Location = new Point(this.button1.Location.X, this.Height / 2);
                this.button1.Text = ">>";

            }
            else if (this.Width - this.panel1.Location.X != 50)
            {
                this.panel1.Left = this.Width - 50;
                this.panel1.Size = new Size(this.Width / 4, this.Height);
                this.button1.Location = new Point(this.button1.Location.X, this.Height / 2);
                this.button1.Text = "<<";
            }
        }
    }
}
