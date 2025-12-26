using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sak
{
    public partial class Form4 : Form
    {
        public static string knev, hnev;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.hido = Convert.ToInt32(textBox3.Text);
                Form1.kido = Convert.ToInt32(textBox3.Text);
                hnev = textBox1.Text;
                knev = textBox2.Text;
                this.Hide();
                Form1 f2 = new Form1();
                f2.ShowDialog();
            }
            catch(Exception)
            {
               label4.Text="Az egyik bemenet rossz";
            }
        }
    }
}
