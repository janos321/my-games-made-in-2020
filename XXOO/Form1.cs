using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace XXOO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] a = new int[10];
        int szamlalo = 0;
        int nyer = 0, kiblokolt = 0;
        Image o = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\XXOO\o.PNG");
        Image x = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\XXOO\xx.PNG");
        private void Form1_Load(object sender, EventArgs e)
        {
            Image myimage = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\XXOO\alap.JPG");
            this.BackgroundImage = myimage;
            Height = 300;
            Width = 389;

        }
        private void nyert()
        {
            label1.Text = "Sajnos vesztettél probálkoz ujból";
            atalakit();
        }
        private void dontetlen()
        {
            label1.Text = "Döntetlen lett probálkoz ujból";
            atalakit();
        }
        private void atalakit()
        {
            Image myimage = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\XXOO\aqua.PNG");
            this.BackgroundImage = myimage;
            label1.Visible = true;
            button1.Visible = true;
            pictureBox1.BackgroundImage = null;
            pictureBox2.BackgroundImage = null;
            pictureBox3.BackgroundImage = null;
            pictureBox4.BackgroundImage = null;
            pictureBox5.BackgroundImage = null;
            pictureBox6.BackgroundImage = null;
            pictureBox7.BackgroundImage = null;
            pictureBox8.BackgroundImage = null;
            pictureBox9.BackgroundImage = null;
        }
        private void ketoldalso()
        {
            if (a[2] == 2 && a[4] == 2&&a[1]==0)
            {
                pictureBox1.BackgroundImage = o;
                a[1] = 1;
            }
            else
               if (a[6] == 2 && a[2] == 2 && a[3] == 0)
            {
                pictureBox3.BackgroundImage = o;
                a[3] = 1;
            }
            else
                if (a[8] == 2 && a[6] == 2 && a[9] == 0)
            {
                pictureBox9.BackgroundImage = o;
                a[9] = 1;
            }
            else
                if (a[4] == 2 && a[8] == 2 && a[7] == 0)
            {
                pictureBox7.BackgroundImage = o;
                a[7] = 1;
            }
            else
                legjobb();
        }
        private void legjobb()
        {
            if (a[1] == 0 && ((a[4] == 1 && a[7] == 0) || (a[7] == 1 && a[4] == 0) || (a[2] == 1 && a[3] == 0) || (a[3] == 1 && a[2] == 0) || (a[5] == 1 && a[9] == 0) || (a[9] == 1 && a[5] == 0)))
            {
                pictureBox1.BackgroundImage = o;
                a[1] = 1;
            }
            else
         if (a[2]==0&&((a[1] == 1 && a[3] == 0) || (a[3] == 1 && a[1] == 0) || (a[5] == 1 && a[8] == 0) || (a[8] == 1 && a[5] == 0)))
            {
                pictureBox2.BackgroundImage = o;
                a[2] = 1;
            }
            else
            if (a[3]==0&&((a[5] == 1 && a[7] == 0) || (a[7] == 1 && a[5] == 0) || (a[6] == 1 && a[9] == 0) || (a[9] == 1 && a[6] == 0) || (a[2] == 1 && a[1] == 0) || (a[1] == 1 && a[2] == 0)))
            {
                pictureBox3.BackgroundImage = o;
                a[3] = 1;
            }
            else
          if (a[4]==0&&((a[1] == 1 && a[7] == 0) || (a[7] == 1 && a[1] == 0) || (a[5] == 1 && a[6] == 0) || (a[6] == 1 && a[5] == 0)))
            {
                pictureBox4.BackgroundImage = o;
                a[4] = 1;
            }
            else
          if (a[5]==0&&((a[2] == 1 && a[8] == 0) || (a[8] == 1 && a[2] == 0) || (a[4] == 1 && a[6] == 0) || (a[6] == 1 && a[4] == 0)||(a[7] == 1 && a[3] == 0) || (a[3] == 1 && a[7] == 0) || (a[1] == 1 && a[9] == 0) || (a[9] == 1 && a[1] == 0)))
            {
                pictureBox5.BackgroundImage = o;
                a[5] = 1;
            }
            else
         if (a[6]==0&&((a[4] == 1 && a[75] == 0) || (a[5] == 1 && a[4] == 0) || (a[9] == 1 && a[3] == 0) || (a[3] == 1 && a[9] == 0)))
            {
                pictureBox6.BackgroundImage = o;
                a[6] = 1;
            }
            else
         if (a[7]==0&&((a[4] == 1 && a[1] == 0) || (a[1] == 1 && a[4] == 0) || (a[8] == 1 && a[9] == 0) || (a[9] == 1 && a[8] == 0) || (a[5] == 1 && a[3] == 0) || (a[3] == 1 && a[5] == 0)))
            {
                pictureBox7.BackgroundImage = o;
                a[7] = 1;
            }
            else
            if (a[8]==0&&((a[5] == 1 && a[2] == 0) || (a[2] == 1 && a[5] == 0) || (a[7] == 1 && a[9] == 0) || (a[9] == 1 && a[7] == 0)))
            {
                pictureBox8.BackgroundImage = o;
                a[8] = 1;
            }
            else
            if (a[9]==0&&((a[5] == 1 && a[1] == 0) || (a[1] == 1 && a[5] == 0) || (a[8] == 1 && a[7] == 0) || (a[7] == 1 && a[8] == 0) || (a[6] == 1 && a[3] == 0) || (a[3] == 1 && a[6] == 0)))
            {
                pictureBox9.BackgroundImage = o;
                a[9] = 1;
            }
            else
                utolso();
        }
        private void utolso()
        {
            if(a[1]==0)
            {
                pictureBox1.BackgroundImage = o;
                a[1] = 1;
            }
            else
                if (a[2] == 0)
            {
                pictureBox2.BackgroundImage = o;
                a[2] = 1;
            }
            else
                if (a[3] == 0)
            {
                pictureBox3.BackgroundImage = o;
                a[3] = 1;
            }
            else
                if (a[4] == 0)
            {
                pictureBox4.BackgroundImage = o;
                a[4] = 1;
            }
            else
                if (a[5] == 0)
            {
                pictureBox5.BackgroundImage = o;
                a[5] = 1;
            }
            else
                if (a[6] == 0)
            {
                pictureBox6.BackgroundImage = o;
                a[6] = 1;
            }
            else
                if (a[7] == 0)
            {
                pictureBox7.BackgroundImage = o;
                a[7] = 1;
            }
            else
            if (a[8] == 0)
            {
                pictureBox8.BackgroundImage = o;
                a[8] = 1;
            }
            else
            if (a[9] == 0)
            {
                pictureBox9.BackgroundImage = o;
                a[9] = 1;
            }
        }
        private void test2()
        {
            if (((a[5] == 1 && a[1] == 1)||(a[6] == 1 && a[3] == 1)||(a[8] == 1 && a[7] == 1)) && a[9] == 0)  //  9-re
            {
                nyer = 1;
                pictureBox9.BackgroundImage = o;
            }
            else
                if (((a[5] == 1 && a[2] == 1)||(a[7] == 1 && a[9] == 1)) && a[8] == 0)  //  8-ra
            {
                nyer = 1;
                pictureBox8.BackgroundImage = o;
            }
            else
                if (((a[4] == 1 && a[1] == 1) || (a[8] == 1 && a[9] == 1) || (a[5] == 1 && a[3] == 1)) && a[7] == 0)// 7-re
            {
                nyer = 1;
                pictureBox7.BackgroundImage = o;
            }
            else
                if (((a[7] == 1 && a[1] == 1) || (a[5] == 1 && a[6] == 1)) && a[4] == 0)  //  4-re
            {
                nyer = 1;
                pictureBox4.BackgroundImage = o;
            }
            else
            if (((a[7] == 1 && a[3] == 1) || (a[1] == 1 && a[9] == 1)||(a[8] == 1 && a[2] == 1) || (a[4] == 1 && a[6] == 1))  && a[5] == 0)  //  5-re
            {
                nyer = 1;
                pictureBox5.BackgroundImage = o;
            }
            else
            if (((a[4] == 1 && a[5] == 1) || (a[9] == 1 && a[3] == 1)) && a[6] == 0)  //  6-ra
            {
                nyer = 1;
                pictureBox6.BackgroundImage = o;
            }
            else
            if (((a[4] == 1 && a[7] == 1) || (a[9] == 1 && a[5] == 1) || (a[2] == 1 && a[3] == 1)) && a[1] == 0)  //  1-re
            {
                nyer = 1;
                pictureBox1.BackgroundImage = o;
            }
            else
            if (((a[8] == 1 && a[5] == 1) || (a[1] == 1 && a[3] == 1)) && a[2] == 0)  //  2-re
            {
                nyer = 1;
                pictureBox2.BackgroundImage = o;
            }
            else
            if (((a[9] == 1 && a[6] == 1) || (a[7] == 1 && a[5] == 1) || (a[2] == 1 && a[1] == 1)) && a[3] == 0)  //  3-ra
            {
                nyer = 1;
                pictureBox3.BackgroundImage = o;
            }
            else
            if (((a[5] == 2 && a[1] == 2) || (a[6] == 2 && a[3] == 2) || (a[8] == 2 && a[7] == 2)) && a[9] == 0)  //  9-re
            {
                a[9] = 1;
                kiblokolt = 1;
                pictureBox9.BackgroundImage = o;
            }
            else
                if (((a[5] == 2 && a[2] == 2) || (a[7] == 2 && a[9] == 2)) && a[8] == 0)  //  8-ra
            {
                a[8] = 1;
                kiblokolt = 1;
                pictureBox8.BackgroundImage = o;
            }
            else
                if (((a[4] == 2 && a[1] == 2) || (a[8] == 2 && a[9] == 2) || (a[5] == 2 && a[3] == 2)) && a[7] == 0)// 7-re
            {
                a[7] = 1;
                kiblokolt = 1;
                pictureBox7.BackgroundImage = o;
            }
            else
                if (((a[7] == 2 && a[1] == 2) || (a[5] == 2 && a[6] == 2)) && a[4] == 0)  //  4-re
            {
                a[4] = 1;
                kiblokolt = 1;
                pictureBox4.BackgroundImage = o;
            }
            else
            if (((a[7] == 2 && a[3] ==2) || (a[1] == 2 && a[9] == 2) || (a[8] == 2 && a[2] == 2) || (a[4] == 2 && a[6] == 2)) && a[5] == 0)  //  5-re
            {
                a[5] = 1;
                kiblokolt = 1;
                pictureBox5.BackgroundImage = o;
            }
            else
            if (((a[4] == 2 && a[5] == 2) || (a[9] == 2 && a[3] == 2)) && a[6] == 0)  //  6-ra
            {
                a[6] = 1;
                kiblokolt = 1;
                pictureBox6.BackgroundImage = o;
            }
            else
            if (((a[4] == 2 && a[7] == 2) || (a[9] == 2 && a[5] == 2) || (a[2] == 2 && a[3] == 2)) && a[1] == 0)  //  1-re
            {
                a[1] = 1;
                kiblokolt = 1;
                pictureBox1.BackgroundImage = o;
            }
            else
            if (((a[8] == 2 && a[5] == 2) || (a[1] == 2 && a[3] == 2)) && a[2] == 0)  //  2-re
            {
                a[2] = 1;
                kiblokolt = 1;
                pictureBox2.BackgroundImage = o;
            }
            else
            if (((a[9] == 2 && a[6] == 2) || (a[7] == 2 && a[5] == 2) || (a[2] == 2 && a[1] == 2)) && a[3] == 0)  //  3-ra
            {
                a[3] = 1;
                kiblokolt = 1;
                pictureBox3.BackgroundImage = o;
            }
        }


        private void test(int n)
        {
            test2();
            if (nyer == 1)
            {
                nyert();
            }
            else
            if (kiblokolt==0)
            {
                if (szamlalo == 1)
                {
                    if (n == 5)  //  kozep
                    {
                        pictureBox3.BackgroundImage = o;
                        a[3] = 1;
                    }
                    else // sarok/oldal
                    {
                        pictureBox5.BackgroundImage = o;
                        a[5] = 1;
                    }
                }
                else
                    if (szamlalo == 2)
                {
                    if(a[5]==2)
                    {
                        pictureBox9.BackgroundImage = o;
                        a[9] = 1;
                    }
                    else
                    if (a[1] == 2 || a[3] == 2 || a[7] == 2 || a[9] == 2)   //  Sarok/oldal, sarok/oldal
                    {
                        if (a[2] != 2&&a[8]!=2)
                        {
                            pictureBox2.BackgroundImage = o;
                            a[2] = 1;
                        }
                        else
                        {
                            pictureBox6.BackgroundImage = o;
                            a[6] = 1;
                        }
                    }
                    else
                    {
                        ketoldalso();
                    }
                }
                if (szamlalo == 3)
                {
                    if (a[1] == 2 || a[3] == 2 || a[7] == 2 || a[9] == 2)   //  Sarok, sarok/oldal
                    {
                        ketoldalso();
                    }
                    else
                        legjobb();
                }
                else
                    if(szamlalo==4)
                {
                    legjobb();
                }
            }
            if(szamlalo==5)
            {
                dontetlen();
            }
            kiblokolt = 0;    
            }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (a[9] == 0)
            {
                szamlalo++;
                a[9] = 2;
                pictureBox9.BackgroundImage = x;
                //Thread.Sleep(1000);
                test(9); 
            }          
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (a[8] == 0)
            {
                szamlalo++;
                a[8] = 2;

                pictureBox8.BackgroundImage = x;
                test(8);
            }       
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (a[7] == 0)
            {
                szamlalo++;
                a[7] = 2;

                pictureBox7.BackgroundImage = x;
                test(7);
            }         
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (a[6] == 0)
            {
                szamlalo++;
                a[6] = 2;

                pictureBox6.BackgroundImage = x;
                test(6);
            }         
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (a[5] == 0)
            {
                szamlalo++;
                a[5] = 2;

                pictureBox5.BackgroundImage = x;
                test(5);
            }          
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (a[4] == 0)
            {
                szamlalo++;
                a[4] = 2;

                pictureBox4.BackgroundImage = x;
                test(4);
            }           
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (a[3] == 0)
            {
                szamlalo++;
                a[3] = 2;
                pictureBox3.BackgroundImage = x;
                test(3);
            }          
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (a[2] == 0)
            {
                szamlalo++;
                a[2] = 2;
                pictureBox2.BackgroundImage = x;
                test(2);
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            szamlalo = 0;
            nyer = 0;
            kiblokolt = 0;
            for(int i=0;i<10;i++)
            {
                a[i] = 0;
            }
            label1.Visible = false;
            button1.Visible = false;
            Image myimage = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\XXOO\alap.JPG");
            this.BackgroundImage = myimage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (a[1] == 0)
            {
                pictureBox1.BackgroundImage = x;
                szamlalo++;
                a[1] = 2;            
                test(1);
            }         
        }
    }
}
