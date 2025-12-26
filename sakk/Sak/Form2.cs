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
    public partial class Form2 : Form
    {

        public static int jelenlegi = 0;
        Image hlo = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\sakk\tbabuk\Chess_nlt60.PNG");
        Image klo = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\sakk\tbabuk\Chess_ndt60.PNG");
        Image hparaszt = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\sakk\tbabuk\Chess_plt60.PNG");
        Image hbastya = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\sakk\tbabuk\Chess_rlt60.PNG");
        Image hfuto = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\sakk\tbabuk\Chess_blt60.PNG");
        Image hkiraly = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\sakk\tbabuk\Chess_klt60.PNG");
        Image hkiralyno = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\sakk\tbabuk\Chess_qlt60.PNG");
        Image kparaszt = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\sakk\tbabuk\Chess_pdt60.PNG");
        Image kbastya = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\sakk\tbabuk\Chess_rdt60.PNG");
        Image kfuto = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\sakk\tbabuk\Chess_bdt60.PNG");
        Image kkiraly = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\sakk\tbabuk\Chess_kdt60.PNG");
        Image kkiralyno = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\sakk\tbabuk\Chess_qdt60.PNG");


        public void hatterleveves()
        {
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
        }
        public Form2()
        {
            InitializeComponent();
            if(Form1.hk==0)
            {
                   // if (Form1.l[1] != 0 )
                   //{
                        pictureBox1.BackgroundImage = hparaszt;
                   // }
                   // if (Form1.l[2] != 0)
               // {
                    pictureBox2.BackgroundImage = hbastya;
               // }
                   // if (Form1.l[3] != 0)
               // {
                    pictureBox3.BackgroundImage = hlo;
               // }
                  //  if (Form1.l[4] != 0)
               // {
                    pictureBox4.BackgroundImage = hfuto;
                //}
                   // if (Form1.l[6] != 0)
               // {
                    pictureBox5.BackgroundImage = hkiralyno;
                //}
            }
            else
            {
               // if (Form1.d[1] != 0)
                //{
                    pictureBox1.BackgroundImage = kparaszt;
                //}
                 //    if (Form1.d[2] != 0)
                //{
                    pictureBox2.BackgroundImage = kbastya;
                //}
                  //   if (Form1.d[3] != 0)
                //{
                    pictureBox3.BackgroundImage = klo;
               // }
                //     if (Form1.d[4] != 0)
               // {
                    pictureBox4.BackgroundImage = kfuto;
                //}
                //    if (Form1.d[6] != 0)
               // {
                    pictureBox5.BackgroundImage = kkiralyno;
                //}
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            hatterleveves();
            pictureBox5.BackColor = Color.Blue;
            jelenlegi = 6;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            hatterleveves();
            pictureBox4.BackColor = Color.Blue;
            jelenlegi = 4;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            hatterleveves();
            pictureBox3.BackColor = Color.Blue;
            jelenlegi = 3;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            hatterleveves();
            pictureBox2.BackColor = Color.Blue;
            jelenlegi = 2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            hatterleveves();
            pictureBox1.BackColor = Color.Blue;
            jelenlegi = 1;
        }
    }
}
