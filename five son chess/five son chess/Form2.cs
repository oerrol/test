using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace five_son_chess
{
    public partial class load : Form
    {
        public load()
        {
            InitializeComponent();
        }

        int a = 0;
        double b = 0.0;
        private void load_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = global::five_son_chess.Properties.Resources.load;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            a++;
            if (a > 2)
            {
                timer1.Enabled = false;
                timer2.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            b--;
            if (b >= 0)
            {
                this.Opacity = b/100;
            }
            else
            {
                Form1 fm1 = new Form1();
                this.Hide();
                fm1.Show();
                timer2.Enabled = false;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            b++;
            if (b <= 100)
            {
                this.Opacity = b / 100;
            }
            else
            {
                timer3.Enabled = false;
                timer1.Enabled = true;
            }
        }
    }
}
