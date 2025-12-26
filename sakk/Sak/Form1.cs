using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Sak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] a = new int[15, 15];
        int[,] zonak = new int[15, 15];
        public static int hk = 0, most = 0, x = 1, y = 1, x2 = 0, y2 = 0, xd = 0, sanc1 = 0, sanc2 = 0, g = 0, sanc11 = 0, sanc12 = 0, sanc21 = 0, sanc22 = 0, sakmatt = 0, ido = 0, feladas = 0,xxd=0;
        int xkkiraly = 1, vizsgal = 0, ykkiraly = 5, xhkiraly = 8, yhkiraly = 5, kk = 0;
        public static int hido = 0, kido = 0;
        public static int[] d = new int[7];
        public static int[] l = new int[7];
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
        Image pont = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\sakk\pont.PNG");
        List<PictureBox> lista = new List<PictureBox>(64);

        private void Form1_Load(object sender, EventArgs e)
        {
            xxd++;
            if (xxd == 1)
            {
                this.Hide();
                Form4 f2 = new Form4();
                f2.ShowDialog();
            }
            label3.Text = Convert.ToString(hido);
            label5.Text = Convert.ToString(kido);
            label4.Text = Form4.knev;
            label2.Text = Form4.hnev;
            hido = hido * 60;
            kido = kido * 60;
            timer1.Enabled = true;
            lista.Add(pictureBox1);
            lista.Add(pictureBox2);
            lista.Add(pictureBox3);
            lista.Add(pictureBox4);
            lista.Add(pictureBox5);
            lista.Add(pictureBox6);
            lista.Add(pictureBox7);
            lista.Add(pictureBox8);
            lista.Add(pictureBox9);
            lista.Add(pictureBox10);
            lista.Add(pictureBox11);
            lista.Add(pictureBox12);
            lista.Add(pictureBox13);
            lista.Add(pictureBox14);
            lista.Add(pictureBox15);
            lista.Add(pictureBox16);
            lista.Add(pictureBox17);
            lista.Add(pictureBox18);
            lista.Add(pictureBox19);
            lista.Add(pictureBox20);
            lista.Add(pictureBox21);
            lista.Add(pictureBox22);
            lista.Add(pictureBox23);
            lista.Add(pictureBox24);
            lista.Add(pictureBox25);
            lista.Add(pictureBox26);
            lista.Add(pictureBox27);
            lista.Add(pictureBox28);
            lista.Add(pictureBox29);
            lista.Add(pictureBox30);
            lista.Add(pictureBox31);
            lista.Add(pictureBox32);
            lista.Add(pictureBox33);
            lista.Add(pictureBox34);
            lista.Add(pictureBox35);
            lista.Add(pictureBox36);
            lista.Add(pictureBox37);
            lista.Add(pictureBox38);
            lista.Add(pictureBox39);
            lista.Add(pictureBox40);
            lista.Add(pictureBox41);
            lista.Add(pictureBox42);
            lista.Add(pictureBox43);
            lista.Add(pictureBox44);
            lista.Add(pictureBox45);
            lista.Add(pictureBox46);
            lista.Add(pictureBox47);
            lista.Add(pictureBox48);
            lista.Add(pictureBox49);
            lista.Add(pictureBox50);
            lista.Add(pictureBox51);
            lista.Add(pictureBox52);
            lista.Add(pictureBox53);
            lista.Add(pictureBox54);
            lista.Add(pictureBox55);
            lista.Add(pictureBox56);
            lista.Add(pictureBox57);
            lista.Add(pictureBox58);
            lista.Add(pictureBox59);
            lista.Add(pictureBox60);
            lista.Add(pictureBox61);
            lista.Add(pictureBox62);
            lista.Add(pictureBox63);
            lista.Add(pictureBox64);
            /*foreach(PictureBox pictureBox in this.Controls.OfType<PictureBox>())
            {
                lista.Add(pictureBox);
            }*/

            //d[1] = 0;
            a[1, 1] = -2; a[1, 8] = -2; a[1, 2] = -3; a[1, 7] = -3; a[1, 3] = -4; a[1, 6] = -4; a[1, 4] = -6; a[1, 5] = -5;  //  feketek
            for (int i = 1; i < 9; i++)  //  parasztok
            {
                a[7, i] = 1;
                a[2, i] = -1;
            }
            for (int j = 0, k = 9; k < 12; k++)
            {
                for (int i = 0; i < 12; i++)
                {
                    a[i, j] = 100;
                    a[i, k] = 100;
                    a[j, i] = 100;
                    a[k, i] = 100;
                    zonak[i, j] = 100;
                    zonak[i, k] = 100;
                    zonak[j, i] = 100;
                    zonak[k, i] = 100;

                }
            }
            a[8, 1] = 2; a[8, 8] = 2; a[8, 2] = 3; a[8, 7] = 3; a[8, 3] = 4; a[8, 6] = 4; a[8, 5] = 5; a[8, 4] = 6;  //  feherek
            Image myimage = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\sakk\tabla.JPG");
            this.BackgroundImage = myimage;
            Height = 700;
            Width = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (hido == 0||kido==0)
            {
                ido = 1;
                timer1.Enabled = false;
                vege();
            }
            if (hk == 0)
            {
                hido--;
                int o = hido / 60;
                label3.Text = Convert.ToString(o+":"+(hido-o*60));
            }
            else
            {
                kido--;
                int o = kido / 60;
                label5.Text = Convert.ToString(o + ":" + (kido - o * 60));
            }

        }
        public void vege()
        {
            this.Hide();
            Form3 f2 = new Form3();
            f2.ShowDialog();
        }
        public void nullazo()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    zonak[i, j] = 0;
                }
            }
        }
        public void veglegkiralyzol()
        {
            for(int i=1;i<9;i++)
            {
                for(int j=1;j<9;j++)
                {
                    if(zonak[i,j]==1)
                    {
                        lista[(i-1)*8+(j-1)].BackgroundImage = pont;
                    }
                    else
                        if(zonak[i, j] == 2)
                    {
                        lista[(i - 1) * 8 + (j - 1)].BackColor = Color.Red;
                    }
                    //zonak[i, j] = 0;
                }
            }
        }
        public void kirajzol()
        {
            if(kk==0)
            nullazo();
            int hatar1 = 0, hatar2 = 7,hatar3=-7,hatar4=0;
            if (most >0)
            {
                hatar1 = -7;
                hatar2 = 0;
                hatar3 = 0;
                hatar4 = 7;
            }
            if (most == 3 || most == -3)
            {
                int t = 7,t2=0;
                if(most==3)
                {
                    t = 0;
                    t2 = -7;
                }
                int p;
                p = a[x + 1, y + 2];
                a[x + 1, y + 2] = a[x, y];
                a[x, y] = 0;
                kiralyvizsgalo();
                a[x, y] = a[x + 1, y + 2];
                a[x + 1, y + 2] = p;
                if (vizsgal == 0)
                {
                    if (a[x + 1, y + 2] == 0)
                    {
                        zonak[x + 1, y + 2] = 1;
                    }
                    else
                    if(a[x + 1, y + 2]<t&& a[x + 1, y + 2] > t2)
                    {
                        zonak[x + 1, y + 2] = 2;
                    }
                }

                p = a[x - 1, y + 2];
                a[x - 1, y + 2] = a[x, y];
                a[x, y] = 0;
                kiralyvizsgalo();
                a[x, y] = a[x - 1, y + 2];
                a[x - 1, y + 2] = p;
                if (vizsgal == 0)
                {
                    if (a[x - 1, y + 2] == 0)
                    {
                        zonak[x - 1, y + 2] = 1;
                    }
                    else
                    if (a[x - 1, y + 2] < t && a[x - 1, y + 2] > t2)
                    {
                        zonak[x - 1, y + 2] = 2;
                    }
                }

                if (x != 1)
                {
                    p = a[x - 2, y + 1];
                    a[x - 2, y + 1] = a[x, y];
                    a[x, y] = 0;
                    kiralyvizsgalo();
                    a[x, y] = a[x - 2, y + 1];
                    a[x - 2, y + 1] = p;
                    if (vizsgal == 0)
                    {
                        if (a[x - 2, y + 1] == 0)
                        {
                            zonak[x - 2, y + 1] = 1;
                        }
                        else
                        if (a[x - 2, y + 1] < t && a[x - 2, y + 1] > t2)
                        {
                            zonak[x - 2, y + 1] = 2;
                        }
                    }

                    p = a[x - 2, y - 1];
                    a[x - 2, y - 1] = a[x, y];
                    a[x, y] = 0;
                    kiralyvizsgalo();
                    a[x, y] = a[x - 2, y - 1];
                    a[x - 2, y - 1] = p;
                    if (vizsgal == 0)
                    {
                        if (a[x - 2, y - 1] == 0)
                        {
                            zonak[x - 2, y - 1] = 1;
                        }
                        else
                        if (a[x - 2, y - 1] < t && a[x - 2, y - 1] > t2)
                        {
                            zonak[x - 2, y - 1] = 2;
                        }
                    }
                }

                p = a[x + 2, y + 1];
                a[x + 2, y + 1] = a[x, y];
                a[x, y] = 0;
                kiralyvizsgalo();
                a[x, y] = a[x + 2, y + 1];
                a[x + 2, y + 1] = p;
                if (vizsgal == 0)
                {
                    if (a[x + 2, y + 1] == 0)
                    {
                        zonak[x + 2, y + 1] = 1;
                    }
                    else
                    if (a[x + 2, y + 1] < t && a[x + 2, y + 1] > t2)
                    {
                        zonak[x + 2, y + 1] = 2;
                    }
                }

                p = a[x + 2, y - 1];
                a[x + 2, y - 1] = a[x, y];
                a[x, y] = 0;
                kiralyvizsgalo();
                a[x, y] = a[x + 2, y - 1];
                a[x + 2, y - 1] = p;
                if (vizsgal == 0)
                {
                    if (a[x + 2, y - 1] == 0)
                    {
                        zonak[x + 2, y - 1] = 1;
                    }
                    else
                    if (a[x + 2, y - 1] < t && a[x + 2, y - 1] > t2)
                    {
                        zonak[x + 2, y - 1] = 2;
                    }
                }
                if(y!=1)
                {
                    p = a[x + 1, y - 2];
                    a[x + 1, y - 2] = a[x, y];
                    a[x, y] = 0;
                    kiralyvizsgalo();
                    a[x, y] = a[x + 1, y - 2];
                    a[x + 1, y - 2] = p;
                    if (vizsgal == 0)
                    {
                        if (a[x + 1, y - 2] == 0)
                        {
                            zonak[x + 1, y - 2] = 1;
                        }
                        else
                        if (a[x + 1, y - 2] < t && a[x + 1, y - 2] > t2)
                        {
                            zonak[x + 1, y - 2] = 2;
                        }
                    }

                    p = a[x - 1, y - 2];
                    a[x - 1, y - 2] = a[x, y];
                    a[x, y] = 0;
                    kiralyvizsgalo();
                    a[x, y] = a[x - 1, y - 2];
                    a[x - 1, y - 2] = p;
                    if (vizsgal == 0)
                    {
                        if (a[x - 1, y - 2] == 0)
                        {
                            zonak[x - 1, y - 2] = 1;
                        }
                        else
                        if (a[x - 1, y - 2] < t && a[x - 1, y - 2] > t2)
                        {
                            zonak[x - 1, y - 2] = 2;
                        }
                    }
                }
            }
            else
           if (most == 2 || most == -2 || most == 6 || most == -6)
            {
                int t=0,p,jelen=a[x,y];
                
                a[x, y] = 0;
                for(int i=x+1;t==0;i++)  ///  le
                {
                    if(a[i, y]==100)
                    {
                        t = 1;
                    }
                    p = a[i, y];
                    a[i, y] = jelen;
                    kiralyvizsgalo();
                    a[i,y] = p;
                    if (a[i, y] > hatar3 && a[i, y] < hatar4)
                    {
                        t = 1;
                    }
                    if (vizsgal == 0)
                    {
                        if (a[i, y] == 0)
                        {
                            zonak[i, y] = 1;
                        }
                        else
                        if (a[i, y] > hatar1 && a[i, y] < hatar2)
                        {
                            zonak[i, y] = 2;
                            t = 1;
                        }
                    }
                }

                t = 0;
                for (int i = x-1; t == 0; i--)  ///  fel
                {
                    if (a[i, y] == 100)
                    {
                        t = 1;
                    }
                    p = a[i, y];
                    a[i, y] = jelen;
                    kiralyvizsgalo();
                    a[i,y] = p;
                    if (a[i, y] > hatar3 && a[i, y] < hatar4)
                    {
                        t = 1;
                    }
                    if (vizsgal == 0)
                    {
                        if (a[i, y] == 0)
                        {
                            zonak[i, y] = 1;
                        }
                        else
                        if (a[i, y] > hatar1 && a[i, y] < hatar2)
                        {
                            zonak[i, y] = 2;
                            t = 1;
                        }
                    }
                }
                t = 0;
                for (int i = y+1; t == 0; i++)  ///  jobbra
                {
                    if (a[x, i] == 100)
                    {
                        t = 1;
                    }
                    p = a[x, i];
                    a[x, i] = jelen;
                    kiralyvizsgalo();
                    a[x,i] = p;
                    if (a[x, i] > hatar3 && a[x, i] < hatar4)
                    {
                        t = 1;
                    }
                    if (vizsgal == 0)
                    {
                        if (a[x, i] == 0)
                        {
                            zonak[x, i] = 1;
                        }
                        else
                        if (a[x, i] > hatar1 && a[x, i] < hatar2)
                        {
                            zonak[x, i] = 2;
                            t = 1;
                        }
                    }
                }

                t = 0;
                for (int i = y -1; t == 0; i--)  ///  bal
                {
                    if (a[x, i] == 100)
                    {
                        t = 1;
                    }
                    p = a[x, i];
                    a[x, i] = jelen;
                    kiralyvizsgalo();
                    a[x, i] = p;
                    if(a[x, i] > hatar3 && a[x, i] < hatar4)
                    {
                        t = 1;
                    }
                    if (vizsgal == 0)
                    {
                        if (a[x, i] == 0)
                        {
                            zonak[x, i] = 1;
                        }
                        else
                        if (a[x, i] > hatar1 && a[x, i] < hatar2)
                        {
                            zonak[x, i] = 2;
                            t = 1;
                        }
                    }
                }

                a[x, y] = jelen;
                
            }
            else
               if (most == 1 || most == -1)
            {
                int  p, jelen = a[x, y];
                a[x, y] = 0;
                if (hk == 0)
                {
                    if(a[x-1,y-1] > hatar1 && a[x - 1, y-1] < hatar2)
                    {
                        p = a[x - 1, y - 1];
                        a[x - 1, y - 1] = jelen;
                        kiralyvizsgalo();
                        a[x - 1, y - 1] = p;
                        if (vizsgal == 0)
                        {
                            zonak[x - 1, y - 1] = 2;
                        }
                    }
                    if (a[x - 1, y + 1] > hatar1 && a[x - 1, y+1] < hatar2)
                    {
                        p = a[x - 1, y + 1];
                        a[x - 1, y + 1] = jelen;
                        kiralyvizsgalo();
                        a[x - 1, y + 1] = p;
                        if (vizsgal == 0)
                        {
                            zonak[x - 1, y + 1] = 2;
                        }
                    }
                    if (a[x-1,y] == 0)
                    {
                        p = a[x - 1, y];
                        a[x - 1, y] = jelen;
                        kiralyvizsgalo();
                        a[x - 1, y] = p;
                        if (vizsgal == 0)
                        {
                            zonak[x - 1, y] = 1;
                        }
                    }
                    if (x==7)
                    {
                        
                        if (a[x - 2, y] == 0&& a[x - 1, y]==0)
                        {
                            p = a[x - 2, y];
                            a[x - 2, y] = jelen;
                            kiralyvizsgalo();
                            a[x - 2, y] = p;
                            if (vizsgal == 0)
                            {
                                zonak[x - 2, y] = 1;
                            }
                        }
                    }
                    
                }
                else
                {
                    if (a[x + 1, y - 1] > hatar1 && a[x + 1, y - 1] < hatar2)
                    {
                        p = a[x + 1, y - 1];
                        a[x + 1, y - 1] = jelen;
                        kiralyvizsgalo();
                        a[x + 1, y - 1] = p;
                        if (vizsgal == 0)
                        {
                            zonak[x + 1, y - 1] = 2;
                        }
                    }
                    if (a[x + 1, y + 1] > hatar1 && a[x + 1, y + 1] < hatar2)
                    {
                        p = a[x + 1, y + 1];
                        a[x + 1, y + 1] = jelen;
                        kiralyvizsgalo();
                        a[x + 1, y + 1] = p;
                        if (vizsgal == 0)
                        {
                            zonak[x + 1, y + 1] = 2;
                        }
                    }
                    if (a[x + 1, y] == 0)
                    {
                        p = a[x + 1, y ];
                        a[x + 1, y ] = jelen;
                        kiralyvizsgalo();
                        a[x + 1, y ] = p;
                        if (vizsgal == 0)
                        {
                            zonak[x + 1, y] = 1;
                        }
                    }
                    if (x == 2)
                    {

                        if (a[x + 2, y] == 0 && a[x + 1, y] == 0)
                        {
                            p = a[x + 2, y];
                            a[x + 2, y] = jelen;
                            kiralyvizsgalo();
                            a[x + 2, y] = p;
                            if (vizsgal == 0)
                            {
                                zonak[x + 2, y] = 1;
                            }
                        }
                    }
                }
                a[x, y]=jelen;

            }
            
               if (most == 4 || most == -4||most==6||most==-6)
            {

                int t = 0, p, jelen = a[x, y];

                a[x, y] = 0;
                for (int i = x + 1,j=y+1; t == 0; i++,j++)  ///  le
                {
                    if (a[i, j] == 100)
                    {
                        t = 1;
                    }
                    p = a[i, j];
                    a[i, j] = jelen;
                    kiralyvizsgalo();
                    a[i, j] = p;
                    if (a[i, j] > hatar3 && a[i, j] < hatar4)
                    {
                        t = 1;
                    }
                    if (vizsgal == 0)
                    {
                        if (a[i, j] == 0)
                        {
                            zonak[i, j] = 1;
                        }
                        else
                        if (a[i, j] > hatar1 && a[i, j] < hatar2)
                        {
                            zonak[i, j] = 2;
                            t = 1;
                        }
                    }
                }
                t = 0;
                for (int i = x - 1, j = y + 1; t == 0; i--, j++)  ///  le
                {
                    if (a[i, j] == 100)
                    {
                        t = 1;
                    }
                    p = a[i, j];
                    a[i, j] = jelen;
                    kiralyvizsgalo();
                    a[i, j] = p;
                    if (a[i, j] > hatar3 && a[i, j] < hatar4)
                    {
                        t = 1;
                    }
                    if (vizsgal == 0)
                    {
                        if (a[i, j] == 0)
                        {
                            zonak[i, j] = 1;
                        }
                        else
                        if (a[i, j] > hatar1 && a[i, j] < hatar2)
                        {
                            zonak[i, j] = 2;
                            t = 1;
                        }
                    }
                }
                t = 0;
                for (int i = x - 1, j = y - 1; t == 0; i--, j--)  ///  le
                {
                    if (a[i, j] == 100)
                    {
                        t = 1;
                    }
                    p = a[i, j];
                    a[i, j] = jelen;
                    kiralyvizsgalo();
                    a[i, j] = p;
                    if (a[i, j] > hatar3 && a[i, j] < hatar4)
                    {
                        t = 1;
                    }
                    if (vizsgal == 0)
                    {
                        if (a[i, j] == 0)
                        {
                            zonak[i, j] = 1;
                        }
                        else
                        if (a[i, j] > hatar1 && a[i, j] < hatar2)
                        {
                            zonak[i, j] = 2;
                            t = 1;
                        }
                    }
                }
                t = 0;
                for (int i = x + 1, j = y - 1; t == 0; i++, j--)  ///  le
                {
                    if (a[i, j] == 100)
                    {
                        t = 1;
                    }
                    p = a[i, j];
                    a[i, j] = jelen;
                    kiralyvizsgalo();
                    a[i, j] = p;
                    if (a[i, j] > hatar3 && a[i, j] < hatar4)
                    {
                        t = 1;
                    }
                    if (vizsgal == 0)
                    {
                        if (a[i, j] == 0)
                        {
                            zonak[i, j] = 1;
                        }
                        else
                        if (a[i, j] > hatar1 && a[i, j] < hatar2)
                        {
                            zonak[i, j] = 2;
                            t = 1;
                        }
                    }
                }
                a[x, y] = jelen;

            }
            else
               if (most == 5 || most == -5)
            {
                if (sanc1 == 0 && hk == 0)
                {
                    sanc(1);
                }
                else
                if (sanc2 == 0 && hk == 1)
                {
                    sanc(2);
                }
                int p, jelen = a[x, y];
                a[x, y] = 0;

                if (hk == 1) xkkiraly++;
                    else
                        xhkiraly++;
                    kiralyvizsgalo();
                    if (hk == 1) xkkiraly--;
                    else
                        xhkiraly--;
                    if (vizsgal == 0)
                    {
                        if (a[x + 1, y] == 0)
                        {
                            zonak[x + 1, y] = 1;
                        }
                        else
                        if (a[x + 1, y] > hatar1 && a[x + 1, y] < hatar2)
                        {
                            zonak[x + 1, y] = 2;
                        }
                    }

                    if (hk == 1) { xkkiraly++; ykkiraly++; }
                    else
                    { xhkiraly++; yhkiraly++;
                }
                    kiralyvizsgalo();
                    if (hk == 1) { xkkiraly--; ykkiraly--; }
                    else
                    { xhkiraly--; yhkiraly--;
                }

                    if (vizsgal == 0)
                    {
                        if (a[x + 1, y + 1] == 0)
                        {
                            zonak[x + 1, y + 1] = 1;
                        }
                        else
                        if (a[x + 1, y + 1] > hatar1 && a[x + 1, y + 1] < hatar2)
                        {
                            zonak[x + 1, y + 1] = 2;
                        }
                    }
                    if (hk == 1) { xkkiraly--; ykkiraly++;  }
                    else
                    { xhkiraly--; yhkiraly++;
                }
                    kiralyvizsgalo();
                    if (hk == 1) { xkkiraly++; ykkiraly--; }
                    else
                    { xhkiraly++; yhkiraly--;
                }
                    if (vizsgal == 0)
                    {
                        if (a[x - 1, y + 1] == 0)
                        {
                            zonak[x - 1, y + 1] = 1;
                        }
                        else
                        if (a[x - 1, y + 1] > hatar1 && a[x - 1, y + 1] < hatar2)
                        {
                            zonak[x - 1, y + 1] = 2;
                        }
                    }

                    if (hk == 1) { xkkiraly++; ykkiraly--; }
                    else
                    { xhkiraly++; yhkiraly--;
                }
                    kiralyvizsgalo();
                    if (hk == 1) { xkkiraly--; ykkiraly++; }
                    else
                    { xhkiraly--; yhkiraly++;
                }
                    if (vizsgal == 0)
                    {
                        if (a[x + 1, y - 1] == 0)
                        {
                            zonak[x + 1, y - 1] = 1;
                        }
                        else
                        if (a[x + 1, y - 1] > hatar1 && a[x + 1, y - 1] < hatar2)
                        {
                            zonak[x + 1, y - 1] = 2;
                        }
                    }


                    if (hk == 1) { ykkiraly++; }
                    else
                        yhkiraly++;
                    kiralyvizsgalo();
                    if (hk == 1) { ykkiraly--; }
                    else
                        yhkiraly--;
                    if (vizsgal == 0)
                    {
                        if (a[x, y + 1] == 0)
                        {
                            zonak[x, y + 1] = 1;
                        }
                        else
                        if (a[x, y + 1] > hatar1 && a[x, y + 1] < hatar2)
                        {
                            zonak[x, y + 1] = 2;
                        }
                    }


                    if (hk == 1) { ykkiraly--; }
                    else
                        yhkiraly--;
                    kiralyvizsgalo();
                    if (hk == 1) { ykkiraly++; }
                    else
                        yhkiraly++;
                    if (vizsgal == 0)
                    {
                        if (a[x, y - 1] == 0)
                        {
                            zonak[x, y - 1] = 1;
                        }
                        else
                        if (a[x, y - 1] > hatar1 && a[x, y - 1] < hatar2)
                        {
                            zonak[x, y - 1] = 2;
                        }
                    }


                    if (hk == 1) { xkkiraly--; ykkiraly--; }
                    else
                    { xhkiraly--; yhkiraly--; }
                    kiralyvizsgalo();
                    if (hk == 1) { xkkiraly++; ykkiraly++; }
                    else
                    { xhkiraly++; yhkiraly++; }
                    if (vizsgal == 0)
                    {
                        if (a[x - 1, y - 1] == 0)
                        {
                            zonak[x - 1, y - 1] = 1;
                        }
                        else
                        if (a[x - 1, y - 1] > hatar1 && a[x - 1, y - 1] < hatar2)
                        {
                            zonak[x - 1, y - 1] = 2;
                        }
                    }


                    if (hk == 1) { xkkiraly--;  }
                    else
                    { xhkiraly--;  }
                    kiralyvizsgalo();
                    if (hk == 1) { xkkiraly++;  }
                    else
                    { xhkiraly++;  }
                    if (vizsgal == 0)
                    {
                        if (a[x - 1, y] == 0)
                        {
                            zonak[x - 1, y] = 1;
                        }
                        else
                        if (a[x - 1, y ] > hatar1 && a[x - 1, y ] < hatar2)
                        {
                            zonak[x - 1, y] = 2;
                        }
                    }
                a[x, y] = jelen;
                
            }  
               if(kk==0)
            veglegkiralyzol();
        }
        public void sanc(int q)
        {
            int p = 0;
            if (q==1)
            {
                if(a[8,6]==0&&a[8,8]==2 && a[8, 7] == 0&&sanc12==0)
                {
                    kiralyvizsgalo();
                    p += vizsgal;
                    yhkiraly = 6;
                    kiralyvizsgalo();
                    p += vizsgal;
                    yhkiraly = 7;
                    kiralyvizsgalo();
                    p += vizsgal;
                    yhkiraly = 8;
                    kiralyvizsgalo();
                    p += vizsgal;
                    yhkiraly = 5;

                    if (p == 0)
                    {
                        zonak[8, 7] = 1;
                    }
                    
                }
                else
                    if(a[8, 4] == 0 && a[8, 1] == 2 && a[8, 2] == 0 && a[8, 3] == 0&&sanc11==0)
                {
                    kiralyvizsgalo();
                    p += vizsgal;
                    yhkiraly = 4;
                    kiralyvizsgalo();
                    p += vizsgal;
                    yhkiraly = 2;
                    kiralyvizsgalo();
                    p += vizsgal;
                    yhkiraly = 3;
                    kiralyvizsgalo();
                    p += vizsgal;
                    yhkiraly = 1;
                    kiralyvizsgalo();
                    p += vizsgal;
                    yhkiraly = 5;
                    if (p == 0)
                    {
                        zonak[8, 3] = 1;
                    }
                }
            }
            else
            {

                if ( a[1, 6] == 0 && a[1, 8] == -2 && a[1, 7] == 0 && sanc22 == 0)
                {                   
                    kiralyvizsgalo();
                    p += vizsgal;
                    ykkiraly = 6;
                    kiralyvizsgalo();
                    p += vizsgal;
                    ykkiraly = 7;
                    kiralyvizsgalo();
                    p += vizsgal;
                    ykkiraly = 8;
                    kiralyvizsgalo();
                    p += vizsgal;
                    ykkiraly = 5;
                    if (p == 0)
                    {
                        zonak[1, 7] = 1;
                    }


                }
                else
                    if ( a[1, 4] == 0 && a[1, 1] == -2 && a[1, 2] == 0 && a[1, 3] == 0 && sanc21 == 0)
                {

                    kiralyvizsgalo();
                    p += vizsgal;
                    ykkiraly = 4;
                    kiralyvizsgalo();
                    p += vizsgal;
                    ykkiraly = 2;
                    kiralyvizsgalo();
                    p += vizsgal;
                    ykkiraly = 3;
                    kiralyvizsgalo();
                    p += vizsgal;
                    ykkiraly = 1;
                    kiralyvizsgalo();
                    p += vizsgal;
                    ykkiraly = 5;
                    if (p == 0)
                    {
                        zonak[1, 3] = 1;
                    }

                }
        
            }
        }
        public void hatteratteves(int x, int y)
        {
            for(int i=0;i<64;i++)
            {
                lista[i].BackColor = Color.Transparent;
                if(lista[i].BackgroundImage==pont)
                {
                    lista[i].BackgroundImage = null;
                }
            }        
        }
        private void babuatteves(Image a, int x, int y)
        {
            lista[(x - 1) * 8 + y-1].BackgroundImage = a;          
        }
        private void sakmat()
        {
            int szamlallllo = 0;
            for (int i = 1; i < 9&&szamlallllo==0; i++)
            {
                for (int j = 1; j < 9&& szamlallllo==0; j++)
                {
                    if (zonak[i, j] == 1)
                    {
                        szamlallllo++;
                    }
                    else
                        if (zonak[i, j] == 2)
                    {
                        szamlallllo++;
                    }

                }
            }
            if(szamlallllo==0)
            {
                sakmatt = 1;
                vege();
            }
            nullazo();
        }
        private void sakm()
        {
            kk = 1;
            int t1 = -1;
            if(hk==0)
            {
                t1 =1;
            }
            for(int i=1;i<9;i++)
            {
                for(int j=1;j<9;j++)
                {
                    if(a[i,j]*t1>0)
                    {
                        most = a[i, j];
                        x = i;
                        y = j;
                        kirajzol();
                    }
                }
            }kk = 0;
            sakmat();
            
        }
        private void rak()
        {
            hatteratteves(1,1);
            nullazo();
            if (most==1||most==-1)
            {
                if (x2 == 1 || x2 == 8)
                {
                    if (hk == 0)
                    {
                        int q = a[x2, y2] * -1;
                        d[q] = 1;
                    }
                    else
                        l[a[x2, y2]] = 1;
                    a[x, y] = 0;
                    Form2 f1 = new Form2();
                    f1.ShowDialog();
                    if (hk == 1)
                    {
                        a[x2, y2] = -1 * Form2.jelenlegi;
                        d[Form2.jelenlegi]--;
                    }
                    else { 
                        a[x2, y2] = Form2.jelenlegi;
                        l[Form2.jelenlegi]--;
                    }
                    if (a[x2, y2] == 1) babuatteves(hparaszt, x2, y2); else
                        if (a[x2, y2] == 2) babuatteves(hbastya, x2, y2);else
                        if (a[x2, y2] == 3) babuatteves(hlo, x2, y2);else
                        if (a[x2, y2] == 4) babuatteves(hfuto, x2, y2);else
                        if (a[x2, y2] == 6) babuatteves(hkiralyno, x2, y2);else
                        if (a[x2, y2] == -1) babuatteves(kparaszt, x2, y2);else
                        if (a[x2, y2] == -2) babuatteves(kbastya, x2, y2);else
                        if (a[x2, y2] == -3) babuatteves(klo, x2, y2);else
                        if (a[x2, y2] == -4) babuatteves(kfuto, x2, y2);else
                        if (a[x2, y2] == -6) babuatteves(kkiralyno, x2, y2);
                }
                else
                {
                    /*if (hk == 0)
                    {
                        int q = a[x2, y2] * -1;
                        d[q] = 1;
                    }
                    else
                        l[a[x2, y2]] = 1;*/
                    
                    a[x2, y2] = a[x, y];
                    a[x, y] = 0;
                    most = 0;
                }
            }
            else
            {
                /*if (hk == 0)
                {
                    int q = a[x2, y2] * -1;
                    d[q] = 1;
                }
                else
                    l[a[x2, y2]] = 1;*/
                a[x2, y2] = a[x, y];    
                a[x, y] = 0;
            most = 0;
            }
            
            if (hk == 0)
            {
                hk = 1;
            }
            else
                hk = 0;

            sakm();
        }
        private void lep()
        {
            if (zonak[x2, y2] != 0) {
                if (most == 3 || most == -3)
                {

                   
                    babuatteves(null, x, y);
                    if (hk == 0)
                    {
                        babuatteves(hlo, x2, y2);
                    }
                    else
                        babuatteves(klo, x2, y2);

                    rak();
                    hatteratteves(x, y);
                }
            else
            if (most == 2 || most == -2)
            {
               
                            babuatteves(null, x, y);
                            if (hk == 0)
                            {
                                if (x == 8 && y == 1)
                                {
                                    sanc11 = 1;
                                }
                                else
                                    if (x == 8 && y == 8)
                                {
                                    sanc12 = 1;
                                }
                                babuatteves(hbastya, x2, y2);
                            }
                            else
                            {
                                if (x == 1 && y == 1)
                                {
                                    sanc21 = 1;
                                }
                                else
                                    if (x == 1 && y == 8)
                                {
                                    sanc22 = 1;
                                }
                                babuatteves(kbastya, x2, y2);
                            }
                            rak();
                            hatteratteves(x, y);
            }
            else
                if (most == 1 || most == -1)
            {

                if (hk == 0)
                {

                            babuatteves(null, x, y);
                            babuatteves(hparaszt, x2, y2);
                            rak();
                   
                }
                else
                {
                            babuatteves(null, x, y);
                            babuatteves(kparaszt, x2, y2);
                            rak();
                            hatteratteves(x, y);                    
                }

            }
            else
                if (most == 4 || most == -4)
            {               
                            babuatteves(null, x, y);
                            if (hk == 0)
                            {
                                babuatteves(hfuto, x2, y2);
                            }
                            else
                                babuatteves(kfuto, x2, y2);
                            rak();
                            hatteratteves(x, y);

            }
            else
                if (most == 5 || most == -5)
            {
                   babuatteves(null, x, y);
                  if (hk == 0)
                  {
                        
                        if (y2==7&& yhkiraly==5)
                   {                            
                            a[8, 8] = 0;
                            a[8, 6] = 2;                            
                            babuatteves(hbastya, 8, 6);
                            babuatteves(null, 8, 8);
                            babuatteves(hkiraly, 8, 7);
                            babuatteves(null, 8, 5);
                            hatteratteves(8, 5);
                        }
                   else
                            if(y2 == 3 && yhkiraly == 5)
                        {
                            a[8, 1] = 0;
                            a[8, 2] = 0;
                            a[8, 4] = 2;
                            babuatteves(hbastya, 8, 4);
                            babuatteves(null, 8, 1);
                            babuatteves(hkiraly, 8, 3);
                            babuatteves(null, 8, 5);
                            hatteratteves(8, 5);
                        }

                  sanc1 = 1;
                   babuatteves(hkiraly, x2, y2);
                  xhkiraly = x2;
                  yhkiraly = y2;

                  }
                  else
                  {
                        if (y2 == 7 && ykkiraly == 5)
                        {
                            a[1, 8] = 0;
                            a[1, 6] = -2;
                            babuatteves(kbastya, 1, 6);
                            babuatteves(null, 1, 8);
                            babuatteves(kkiraly, 1, 7);
                            babuatteves(null, 1, 5);
                            hatteratteves(1, 5);
                        }
                        else
                            if (y2 == 3 && ykkiraly == 5)
                        {
                            a[1, 1] = 0;
                            a[1, 2] = 0;
                            a[1, 4] = -2;
                            babuatteves(kbastya, 1, 4);
                            babuatteves(null, 1, 1);
                            babuatteves(kkiraly, 1, 3);
                            babuatteves(null, 1, 5);
                            hatteratteves(1, 5);
                        }
                        sanc2 = 1;
                   babuatteves(kkiraly, x2, y2);
                   xkkiraly = x2;
                   ykkiraly = y2;
                   }

                  rak();
              hatteratteves(x, y);
            }
            else
                if (most == 6 || most == -6)
            {
               
                            babuatteves(null, x, y);
                            if (hk == 0)
                            {
                                babuatteves(hkiralyno, x2, y2);
                            }
                            else
                                babuatteves(kkiralyno, x2, y2);
                            rak();
                            hatteratteves(x, y);                      
            }
            nullazo();
        }
        }
        private void kiralyvizsgalo()
        {
            int szamlalo = 0,t1=1,t=1,t2=1,t3=1,t4=1,x3=0,y3=0;
            if (hk == 0) {
                x3 = xhkiraly;
                y3 = yhkiraly;
                t = -1;
            }
            else
            {
                x3 = xkkiraly;
                y3 = ykkiraly;
            }
            if (a[x3, y3] != 100)
            {
                if (a[x3 + t * 1, y3 - 1] == t * 1 || a[x3 + t * 1, y3 + 1] == t * 1)  //  paraszt
                {
                    szamlalo = 1;
                }
                for (int i = x3 + 1, i2 = x3 - 1, j = y3 + 1, j2 = y3 - 1; t1 == 1 || t2 == 1 || t3 == 1 || t4 == 1; i += t1, i2 -= t2, j += t3, j2 -= t4)
                {
                    if (a[i, y3] == 6 * t || a[i, y3] == 2 * t && t1 == 1)
                    {
                        szamlalo = 2;

                    }
                    else
                        if (a[i, y3] != 0 && t1 == 1)
                    {
                        t1 = 0;
                    }
                    if (a[i2, y3] == 6 * t || a[i2, y3] == 2 * t && t2 == 1)
                    {
                        szamlalo = 3;
                    }
                    else
                        if (a[i2, y3] != 0 && t2 == 1)
                    {
                        t2 = 0;
                    }


                    if (a[x3, j] == 6 * t || a[x3, j] == 2 * t && t3 == 1)
                    {
                        szamlalo = 4;

                    }
                    else
                           if (a[x3, j] != 0 && t3 == 1)
                    {
                        t3 = 0;
                    }
                    if (a[x3, j2] == 6 * t || a[x3, j2] == 2 * t && t4 == 1)
                    {
                        szamlalo = 5;
                    }
                    else
                        if (a[x3, j2] != 0 && t4 == 1)
                    {
                        t4 = 0;
                    }
                }   //  jobra,balra,elolre,hatra
                t1 = 1; t2 = 1; t3 = 1; t4 = 1;
                for (int i1 = x3 - 1, j1 = y3 - 1, i2 = x3 + 1, j2 = y3 + 1, i3 = x3 - 1, j3 = y3 + 1, i4 = x3 + 1, j4 = y3 - 1; t1 == 1 || t2 == 1 || t3 == 1 || t4 == 1; i1 -= t1, j1 -= t1, i2 += t2, j2 += t2, i3 -= t3, j3 += t3, i4 += t4, j4 -= t4)
                {
                    if ((a[i1, j1] == 6 * t || a[i1, j1] == 4 * t) && t1 == 1)
                    {
                        szamlalo = 6;

                    }
                    else
                            if (a[i1, j1] != 0 && t1 == 1)
                    {
                        t1 = 0;
                    }

                    if ((a[i2, j2] == 6 * t || a[i2, j2] == 4 * t) && t2 == 1)
                    {
                        szamlalo = 7;

                    }
                    else
                            if (a[i2, j2] != 0 && t2 == 1)
                    {
                        t2 = 0;
                    }
                    if ((a[i3, j3] == 6 * t || a[i3, j3] == 4 * t) && t3 == 1)
                    {
                        szamlalo = 8;

                    }
                    else
                            if (a[i3, j3] != 0 && t3 == 1)
                    {
                        t3 = 0;
                    }
                    if ((a[i4, j4] == 6 * t || a[i4, j4] == 4 * t) && t4 == 1)
                    {
                        szamlalo = 9;

                    }
                    else
                            if (a[i4, j4] != 0 && t4 == 1)
                    {
                        t4 = 0;
                    }
                }  //  slegan minden iranyba
                if (x3 > 1 && y3 > 1)
                {
                    if (a[x3 + 1, y3 + 2] == t * 3 || a[x3 - 1, y3 + 2] == t * 3 || a[x3 - 2, y3 + 1] == t * 3 || a[x3 + 2, y3 + 1] == t * 3 || a[x3 + 2, y3 - 1] == t * 3 || a[x3 - 2, y3 - 1] == t * 3 || a[x3 - 1, y3 - 2] == t * 3 || a[x3 + 1, y3 - 2] == t * 3)
                    {
                        szamlalo = 10;
                    }
                }
                else
                {
                    if (x3 == 1 && y3 == 1)
                    {
                        if (a[x3 + 1, y3 + 2] == t * 3 || a[x3 + 2, y3 + 1] == t * 3)
                        {
                            szamlalo = 11;
                        }
                    }
                    else
                    if (x3 == 1)
                    {
                        if (a[x3 + 1, y3 - 2] == t * 3 || a[x3 + 1, y3 + 2] == t * 3 || a[x3 + 2, y3 - 1] == t * 3 || a[x3 + 2, y3 + 1] == t * 3)
                        {
                            szamlalo = 11;
                        }
                    }
                    else
                        if (y3 == 1)
                    {
                        if (a[x3 + 1, y3 + 2] == t * 3 || a[x3 - 1, y3 + 2] == t * 3 || a[x3 + 2, y3 + 1] == t * 3 || a[x3 - 2, y3 + 1] == t * 3)
                        {
                            szamlalo = 12;
                        }

                    }
                }

                if (a[x3 + 1, y3 + 1] == t * 5 || a[x3 + 1, y3] == t * 5 || a[x3 + 1, y3 - 1] == t * 5 || a[x3, y3 + 1] == t * 5 || a[x3, y3 - 1] == t * 5 || a[x3 - 1, y3 + 1] == t * 5 || a[x3 - 1, y3 - 1] == t * 5 || a[x3 - 1, y3] == t * 5)
                {
                    szamlalo = 13;
                }

                if (szamlalo != 0)
                {

                    vizsgal = 1;
                }
                else
                {
                    vizsgal = 0;
                }
            }
            else
            {
                vizsgal = 1;
            }
        }
        private void pictureBox63_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[8, 7] > 0 || hk == 1 && a[8, 7] < 0)
            {
                hatteratteves(x, y);
                pictureBox63.BackColor = Color.Green;
                most = a[8, 7];
                x = 8;
                y = 7;
            kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 8;
                    y2 = 7;
                    lep();
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[1, 1] > 0 || hk == 1 && a[1, 1] < 0)
            {
                hatteratteves(x, y);
                pictureBox1.BackColor = Color.Green;
                x = 1;
                y = 1;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 1;
                    y2 = 1;
                    lep();
                }
            }
        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[8, 6] > 0 || hk == 1 && a[8, 6] < 0)
            {
                hatteratteves(x, y);
                pictureBox62.BackColor = Color.Green;
                most = a[8, 6];
                x = 8;
                y = 6;
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 8;
                    y2 = 6;
                    lep();
                }
            }
        }

        private void pictureBox61_Click(object sender, EventArgs e)
        {

            if (hk == 0 && a[8, 5] > 0 || hk == 1 && a[8, 5] < 0)
            {
                hatteratteves(x, y);
                pictureBox61.BackColor = Color.Green;
                most = a[8, 5];
                x = 8;
                y = 5;
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 8;
                    y2 = 5;
                    lep();
                }
            }
        }

        private void pictureBox60_Click(object sender, EventArgs e)
        {

            if (hk == 0 && a[8, 4] > 0 || hk == 1 && a[8, 4] < 0)
            {
                hatteratteves(x, y);
                pictureBox60.BackColor = Color.Green;
                most = a[8, 4];
                x = 8;
                y = 4;
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 8;
                    y2 = 4;
                    lep();
                }
            }
        }

        private void pictureBox59_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[8, 3] > 0 || hk == 1 && a[8, 3] < 0)
            {
                hatteratteves(x, y);
                pictureBox59.BackColor = Color.Green;
                x = 8;
                y = 3;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 8;
                    y2 = 3;
                    lep();
                }
            }
        }

        private void pictureBox58_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[8, 2] > 0 || hk == 1 && a[8, 2] < 0)
            {
                hatteratteves(x, y);
                pictureBox58.BackColor = Color.Green;
                x = 8;
                y = 2;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 8;
                    y2 = 2;
                    lep();
                }
            }
        }

        private void pictureBox57_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[8, 1] > 0 || hk == 1 && a[8, 1] < 0)
            {
                hatteratteves(x, y);
                pictureBox57.BackColor = Color.Green;
                x = 8;
                y = 1;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 8;
                    y2 = 1;
                    lep();
                }
            }
        }

        private void pictureBox56_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[7, 8] > 0 || hk == 1 && a[7, 8] < 0)
            {
                hatteratteves(x, y);
                pictureBox56.BackColor = Color.Green;
                most = a[7, 8];
                x = 7;
                y = 8;
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 7;
                    y2 = 8;
                    lep();
                }
            }
        }

        private void pictureBox55_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[7, 7] > 0 || hk == 1 && a[7, 7] < 0)
            {
                hatteratteves(x, y);
                pictureBox55.BackColor = Color.Green;
                x = 7;
                y = 7;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 7;
                    y2 = 7;
                    lep();
                }
            }
        }

        private void pictureBox54_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[7, 6] > 0 || hk == 1 && a[7, 6] < 0)
            {
                hatteratteves(x, y);
                pictureBox54.BackColor = Color.Green;
                most = a[7, 6];
                x = 7;
                y = 6;
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 7;
                    y2 = 6;
                    lep();
                }
            }
        }

        private void pictureBox53_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[7, 5] > 0 || hk == 1 && a[7, 5] < 0)
            {
                hatteratteves(x, y);
                pictureBox53.BackColor = Color.Green;
                most = a[7, 5];
                x = 7;
                y = 5;
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 7;
                    y2 = 5;
                    lep();
                }
            }
        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[7, 4] > 0 || hk == 1 && a[7, 4] < 0)
            {
                hatteratteves(x, y);
                pictureBox52.BackColor = Color.Green;
                most = a[7, 4];
                x = 7;
                y = 4;
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 7;
                    y2 = 4;
                    lep();
                }
            }
        }

        private void pictureBox51_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[7, 3] > 0 || hk == 1 && a[7, 3] < 0)
            {
                hatteratteves(x, y);
                pictureBox51.BackColor = Color.Green;
                x = 7;
                y = 3;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 7;
                    y2 = 3;
                    lep();
                }
            }
        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[7, 2] > 0 || hk == 1 && a[7, 2] < 0)
            {
                hatteratteves(x, y);
                pictureBox50.BackColor = Color.Green;
                x = 7;
                y = 2;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 7;
                    y2 = 2;
                    lep();
                }
            }
        }

        private void pictureBox49_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[7, 1] > 0 || hk == 1 && a[7, 1] < 0)
            {
                hatteratteves(x, y);
                pictureBox49.BackColor = Color.Green;
                x = 7;
                y = 1;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 7;
                    y2 = 1;
                    lep();
                }
            }
        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[6, 8] > 0 || hk == 1 && a[6, 8] < 0)
            {
                hatteratteves(x, y);
                pictureBox48.BackColor = Color.Green;
                most = a[6, 8];
                x = 6;
                y = 8;
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 6;
                    y2 = 8;
                    lep();
                }
            }
        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[6, 7] > 0 || hk == 1 && a[6, 7] < 0)
            {
                hatteratteves(x, y);
                pictureBox47.BackColor = Color.Green;
                x = 6;
                y = 7;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 6;
                    y2 = 7;
                    lep();
                }
            }
        }

        private void pictureBox46_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[6, 6] > 0 || hk == 1 && a[6, 6] < 0)
            {
                hatteratteves(x, y);
                pictureBox46.BackColor = Color.Green;
                most = a[6, 6];
                x = 6;
                y = 6;
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 6;
                    y2 = 6;
                    lep();
                }
            }
        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[6, 5] > 0 || hk == 1 && a[6, 5] < 0)
            {
                hatteratteves(x, y);
                pictureBox45.BackColor = Color.Green;
                most = a[6, 5];
                x = 6;
                y = 5;
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 6;
                    y2 = 5;
                    lep();
                }
            }
        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[6, 4] > 0 || hk == 1 && a[6, 4] < 0)
            {
                hatteratteves(x, y);
                pictureBox44.BackColor = Color.Green;
                x = 6;
                y = 4;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 6;
                    y2 = 4;
                    lep();
                }
            }
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[6, 3] > 0 || hk == 1 && a[6, 3] < 0)
            {
                hatteratteves(x, y);
                pictureBox43.BackColor = Color.Green;
                x = 6;
                y = 3;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 6;
                    y2 = 3;
                    lep();
                }
            }
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[6, 2] > 0 || hk == 1 && a[6, 2] < 0)
            {
                hatteratteves(x, y);
                pictureBox42.BackColor = Color.Green;
                x = 6;
                y = 2;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 6;
                    y2 = 2;
                    lep();
                }
            }
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[6, 1] > 0 || hk == 1 && a[6, 1] < 0)
            {
                hatteratteves(x, y);
                pictureBox41.BackColor = Color.Green;
                x = 6;
                y = 1;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 6;
                    y2 = 1;
                    lep();
                }
            }
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[5, 8] > 0 || hk == 1 && a[5, 8] < 0)
            {
                hatteratteves(x, y);
                pictureBox40.BackColor = Color.Green;
                x = 5;
                y = 8;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 5;
                    y2 = 8;
                    lep();
                }
            }
        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[5, 7] > 0 || hk == 1 && a[5, 7] < 0)
            {
                hatteratteves(x, y);
                pictureBox39.BackColor = Color.Green;
                x = 5;
                y = 7;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 5;
                    y2 = 7;
                    lep();
                }
            }
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[5, 6] > 0 || hk == 1 && a[5, 6] < 0)
            {
                hatteratteves(x, y);
                pictureBox38.BackColor = Color.Green;
                x = 5;
                y = 6;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 5;
                    y2 = 6;
                    lep();
                }
            }
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[5, 5] > 0 || hk == 1 && a[5, 5] < 0)
            {
                hatteratteves(x, y);
                pictureBox37.BackColor = Color.Green;
                x = 5;
                y = 5;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 5;
                    y2 = 5;
                    lep();
                }
            }
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[5, 4] > 0 || hk == 1 && a[5, 4] < 0)
            {
                hatteratteves(x, y);
                pictureBox36.BackColor = Color.Green;
                most = a[5, 4];
                x = 5;
                y = 4;
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 5;
                    y2 = 4;
                    lep();
                }
            }
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[5, 3] > 0 || hk == 1 && a[5, 3] < 0)
            {
                hatteratteves(x, y);
                pictureBox35.BackColor = Color.Green;
                x = 5;
                y = 3;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 5;
                    y2 = 3;
                    lep();
                }
            }
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[5, 2] > 0 || hk == 1 && a[5, 2] < 0)
            {
                hatteratteves(x, y);
                pictureBox34.BackColor = Color.Green;
                x = 5;
                y =2;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 5;
                    y2 = 2;
                    lep();
                }
            }
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[5, 1] > 0 || hk == 1 && a[5, 1] < 0)
            {
                hatteratteves(x, y);
                pictureBox33.BackColor = Color.Green;
                x = 5;
                y = 1;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 5;
                    y2 = 1;
                    lep();
                }
            }
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[4, 8] > 0 || hk == 1 && a[4, 8] < 0)
            {
                hatteratteves(x, y);
                pictureBox32.BackColor = Color.Green;
                x = 4;
                y = 8;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 4;
                    y2 = 8;
                    lep();
                }
            }
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[4, 7] > 0 || hk == 1 && a[4, 7] < 0)
            {
                hatteratteves(x, y);
                pictureBox31.BackColor = Color.Green;
                x = 4;
                y = 7;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 4;
                    y2 = 7;
                    lep();
                }
            }
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[4, 6] > 0 || hk == 1 && a[4, 6] < 0)
            {
                hatteratteves(x, y);
                pictureBox30.BackColor = Color.Green;
                x = 4;
                y = 6;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 4;
                    y2 = 6;
                    lep();
                }
            }
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[4, 5] > 0 || hk == 1 && a[4, 5] < 0)
            {
                hatteratteves(x, y);
                pictureBox29.BackColor = Color.Green;
                x = 4;
                y = 5;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 4;
                    y2 = 5;
                    lep();
                }
            }
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[4, 4] > 0 || hk == 1 && a[4, 4] < 0)
            {
                hatteratteves(x, y);
                pictureBox28.BackColor = Color.Green;
                x = 4;
                y = 4;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 4;
                    y2 = 4;
                    lep();
                }
            }
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[4, 3] > 0 || hk == 1 && a[4, 3] < 0)
            {
                hatteratteves(x, y);
                pictureBox27.BackColor = Color.Green;
                x = 4;
                y = 3;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 4;
                    y2 = 3;
                    lep();
                }
            }
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[4, 2] > 0 || hk == 1 && a[4, 2] < 0)
            {
                hatteratteves(x, y);
                pictureBox26.BackColor = Color.Green;
                x = 4;
                y = 2;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 4;
                    y2 = 2;
                    lep();
                }
            }
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[4, 1] > 0 || hk == 1 && a[4, 1] < 0)
            {
                hatteratteves(x, y);
                pictureBox25.BackColor = Color.Green;
                x = 4;
                y = 1;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 4;
                    y2 = 1;
                    lep();
                }
            }
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[3, 8] > 0 || hk == 1 && a[3, 8] < 0)
            {
                hatteratteves(x, y);
                pictureBox24.BackColor = Color.Green;
                x = 3;
                y = 8;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 3;
                    y2 = 8;
                    lep();
                }
            }
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[3, 7] > 0 || hk == 1 && a[3, 7] < 0)
            {
                hatteratteves(x, y);
                pictureBox23.BackColor = Color.Green;
                x = 3;
                y = 7;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 3;
                    y2 = 7;
                    lep();
                }
            }
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[3, 6] > 0 || hk == 1 && a[3, 6] < 0)
            {
                hatteratteves(x, y);
                pictureBox22.BackColor = Color.Green;
                x = 3;
                y = 6;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 3;
                    y2 = 6;
                    lep();
                }
            }
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[3, 5] > 0 || hk == 1 && a[3, 5] < 0)
            {
                hatteratteves(x, y);
                pictureBox21.BackColor = Color.Green;
                x = 3;
                y = 5;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 3;
                    y2 = 5;
                    lep();
                }
            }
        }



        private void pictureBox20_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[3, 4] > 0 || hk == 1 && a[3, 4] < 0)
            {
                hatteratteves(x, y);
                pictureBox20.BackColor = Color.Green;
                x = 3;
                y = 4;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 3;
                    y2 = 4;
                    lep();
                }
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[3, 3] > 0 || hk == 1 && a[3, 3] < 0)
            {
                hatteratteves(x, y);
                pictureBox19.BackColor = Color.Green;
                x = 3;
                y = 3;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 3;
                    y2 = 3;
                    lep();
                }
            }
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[3, 2] > 0 || hk == 1 && a[3, 2] < 0)
            {
                hatteratteves(x, y);
                pictureBox18.BackColor = Color.Green;
                x = 3;
                y = 2;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 3;
                    y2 = 2;
                    lep();
                }
            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[3, 1] > 0 || hk == 1 && a[3, 1] < 0)
            {
                hatteratteves(x, y);
                pictureBox17.BackColor = Color.Green;
                x = 3;
                y =1;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 3;
                    y2 = 1;
                    lep();
                }
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[2, 8] > 0 || hk == 1 && a[2, 8] < 0)
            {
                hatteratteves(x, y);
                pictureBox16.BackColor = Color.Green;
                x = 2;
                y = 8;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 2;
                    y2 = 8;
                    lep();
                }
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[2, 7] > 0 || hk == 1 && a[2, 7] < 0)
            {
                hatteratteves(x, y);
                pictureBox15.BackColor = Color.Green;
                x = 2;
                y = 7;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 2;
                    y2 = 7;
                    lep();
                }
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[2, 6] > 0 || hk == 1 && a[2,6] < 0)
            {
                hatteratteves(x, y);
                pictureBox14.BackColor = Color.Green;
                x = 2;
                y = 6;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 2;
                    y2 = 6;
                    lep();
                }
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[2, 5] > 0 || hk == 1 && a[2, 5] < 0)
            {
                hatteratteves(x, y);
                pictureBox13.BackColor = Color.Green;
                x = 2;
                y = 5;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 2;
                    y2 = 5;
                    lep();
                }
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[2, 4] > 0 || hk == 1 && a[2, 4] < 0)
            {
                hatteratteves(x, y);
                pictureBox12.BackColor = Color.Green;
                x = 2;
                y = 4;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 2;
                    y2 = 4;
                    lep();
                }
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[2, 3] > 0 || hk == 1 && a[2, 3] < 0)
            {
                hatteratteves(x, y);
                pictureBox11.BackColor = Color.Green;
                x = 2;
                y = 3;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 2;
                    y2 = 3;
                    lep();
                }
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[2, 2] > 0 || hk == 1 && a[2, 2] < 0)
            {
                hatteratteves(x, y);
                pictureBox10.BackColor = Color.Green;
                x = 2;
                y = 2;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 2;
                    y2 = 2;
                    lep();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            feladas = 1;
            vege();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[2, 1] > 0 || hk == 1 && a[2, 1] < 0)
            {
                hatteratteves(x, y);
                pictureBox9.BackColor = Color.Green;
                x = 2;
                y = 1;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 2;
                    y2 = 1;
                    lep();
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[1, 8] > 0 || hk == 1 && a[1, 8] < 0)
            {
                hatteratteves(x, y);
                pictureBox8.BackColor = Color.Green;
                x = 1;
                y = 8;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 1;
                    y2 = 8;
                    lep();
                }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[1, 7] > 0 || hk == 1 && a[1, 7] < 0)
            {
                hatteratteves(x, y);
                pictureBox7.BackColor = Color.Green;
                x = 1;
                y = 7;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 1;
                    y2 = 7;
                    lep();
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[1, 6] > 0 || hk == 1 && a[1, 6] < 0)
            {
                hatteratteves(x, y);
                pictureBox6.BackColor = Color.Green;
                x = 1;
                y = 6;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 1;
                    y2 = 6;
                    lep();
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[1, 5] > 0 || hk == 1 && a[1, 5] < 0)
            {
                hatteratteves(x, y);
                pictureBox5.BackColor = Color.Green;
                x = 1;
                y = 5;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 1;
                    y2 = 5;
                    lep();
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[1, 4] > 0 || hk == 1 && a[1, 4] < 0)
            {
                hatteratteves(x, y);
                pictureBox4.BackColor = Color.Green;
                x = 1;
                y = 4;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 1;
                    y2 = 4;
                    lep();
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[1, 3] > 0 || hk == 1 && a[1, 3] < 0)
            {
                hatteratteves(x, y);
                pictureBox3.BackColor = Color.Green;
                x = 1;
                y = 3;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 1;
                    y2 = 3;
                    lep();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[1, 2] > 0 || hk == 1 && a[1, 2] < 0)
            {
                hatteratteves(x, y);
                pictureBox2.BackColor = Color.Green;
                x = 1;
                y = 2;
                most = a[x, y];
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 1;
                    y2 = 2;
                    lep();
                }
            }
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            if (hk == 0 && a[8, 8] > 0 || hk == 1 && a[8, 8] < 0)
            {
                hatteratteves(x, y);
                pictureBox64.BackColor = Color.Green;
                most = a[8, 8];
                x = 8;
                y = 8;
                kirajzol();
            }
            else
            {
                if (most != 0)
                {
                    x2 = 8;
                    y2 = 8;
                    lep();
                }
            }
        }
    }
}
