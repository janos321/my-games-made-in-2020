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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int most = 0;
        int x2 = 0, y2 = 0, osszeg = 0;
        int[,] a = new int[64, 64];
        Image fekete = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\Othello\689289.GIF");
        Image feher = new Bitmap(@"C:\Users\hjano\OneDrive\Desktop\Othello\feher.PNG");
        List<PictureBox> lista = new List<PictureBox>(64);
        public Form1()
        {

            int k1 = 0, k2 = 9;
            for (int j = 0; j <= 9; j++)
            {
                a[j, k1] = 100;
                a[k1, j] = 100;
                a[j, k2] = 100;
                a[k2, j] = 100;

            }
            for (int i = 1; i < 9; i++)
            { for (int j = 1; j < 9; j++)
                {
                    a[i, j] = 0;
                }
            }

            InitializeComponent();
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
            lista.Add(pictureBox233);
            lista.Add(pictureBox24);
            lista.Add(pictureBox25);
            lista.Add(pictureBox26);
            lista.Add(pictureBox277);
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
        }
        public void nez(int x, int y, int fajta)
        {
            int o = 2;
            Image xd;
            if (fajta == 2)
            {
                o = 1;
                xd = feher;
            }
            else
                xd = fekete;
            int i = x, j = y, t = 0;
            while (t == 0)  /// le
            {

                i++; if (fajta != a[i, j])
                {
                    t = 1;
                }
                if (a[x, y] == a[i, j])
                {
                    for (int k = x + 1; k < i; k++)
                    {
                        Task.Delay(500).Wait();
                        lista[(k - 1) * 8 + y - 1].BackgroundImage = xd;
                        lista[(k - 1) * 8 + y - 1].BackColor = Color.Yellow;
                        if (o == 1)
                        {
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + 1);
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) - 1);
                        }
                        else
                        {
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + 1);
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - 1);
                        }
                        a[k, y] = o;
                    }
                }


            }
            i = x; j = y; t = 0;
            while (t == 0)  /// fel
            {
                i--;
                if (a[x, y] == a[i, j])
                {
                    for (int k = x - 1; k > i; k--)
                    {
                        Task.Delay(500).Wait();
                        a[k, y] = o;
                        lista[(k - 1) * 8 + y - 1].BackgroundImage = xd;
                        lista[(k - 1) * 8 + y - 1].BackColor = Color.Yellow;
                        if (o == 1)
                        {
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + 1);
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) - 1);
                        }
                        else
                        {
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + 1);
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - 1);
                        }

                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }

            }
            i = x; j = y; t = 0;
            while (t == 0)  /// jobbra
            {
                j++;
                if (a[x, y] == a[i, j])
                {
                    for (int k = y + 1; k < j; k++)
                    {
                        Task.Delay(500).Wait();
                        a[x, k] = o;
                        lista[(x - 1) * 8 + k - 1].BackgroundImage = xd;
                        lista[(x - 1) * 8 + k - 1].BackColor = Color.Yellow;
                        if (o == 1)
                        {
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + 1);
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) - 1);
                        }
                        else
                        {
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + 1);
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - 1);
                        }
                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }

            }
            i = x; j = y; t = 0;
            while (t == 0)  /// balra
            {
                j--;
                if (a[x, y] == a[i, j])
                {
                    for (int k = y - 1; k > j; k--)
                    {
                        Task.Delay(500).Wait();
                        a[x, k] = o;
                        lista[(x - 1) * 8 + k - 1].BackgroundImage = xd;
                        lista[(x - 1) * 8 + k - 1].BackColor = Color.Yellow;
                        if (o == 1)
                        {
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + 1);
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) - 1);
                        }
                        else
                        {
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + 1);
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - 1);
                        }
                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }
            }
            i = x; j = y; t = 0;
            while (t == 0)  /// slegan fel jobbra
            {
                j++;
                i--;
                if (a[x, y] == a[i, j])
                {
                    for (int k = y + 1, l = x - 1; k < j; k++, l--)
                    {
                        Task.Delay(500).Wait();
                        a[l, k] = o;
                        lista[(l - 1) * 8 + k - 1].BackgroundImage = xd;
                        lista[(l - 1) * 8 + k - 1].BackColor = Color.Yellow;
                        if (o == 1)
                        {
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + 1);
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) - 1);
                        }
                        else
                        {
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + 1);
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - 1);
                        }
                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }
            }
            i = x; j = y; t = 0;
            while (t == 0)  /// slegan fel balra
            {
                j--;
                i--;
                if (a[x, y] == a[i, j])
                {
                    for (int k = y - 1, l = x - 1; k > j; k--, l--)
                    {
                        Task.Delay(500).Wait();
                        a[l, k] = o;
                        lista[(l - 1) * 8 + k - 1].BackgroundImage = xd;
                        lista[(l - 1) * 8 + k - 1].BackColor = Color.Yellow;
                        if (o == 1)
                        {
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + 1);
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) - 1);
                        }
                        else
                        {
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + 1);
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - 1);
                        }
                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }
            }
            i = x; j = y; t = 0;
            while (t == 0)  /// slegan le jobbra
            {
                j++;
                i++;
                if (a[x, y] == a[i, j])
                {
                    for (int k = y + 1, l = x + 1; k < j; k++, l++)
                    {
                        Task.Delay(500).Wait();
                        a[l, k] = o;
                        lista[(l - 1) * 8 + k - 1].BackgroundImage = xd;
                        lista[(l - 1) * 8 + k - 1].BackColor = Color.Yellow;
                        if (o == 1)
                        {
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + 1);
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) - 1);
                        }
                        else
                        {
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + 1);
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - 1);
                        }
                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }
            }
            i = x; j = y; t = 0;
            while (t == 0)  /// slegan le balra
            {
                j--;
                i++;
                if (a[x, y] == a[i, j])
                {
                    for (int k = y - 1, l = x + 1; k > j; k--, l++)
                    {
                        Task.Delay(500).Wait();
                        a[l, k] = o;
                        lista[(l - 1) * 8 + k - 1].BackgroundImage = xd;
                        lista[(l - 1) * 8 + k - 1].BackColor = Color.Yellow;
                        if (o == 1)
                        {
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + 1);
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) - 1);
                        }
                        else
                        {
                            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + 1);
                            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - 1);
                        }

                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }
            }

        }
        public void szamlalo(int x, int y, int fajta)
        {
            osszeg = 0;
            int i = x, j = y, t = 0;
            while (t == 0)  /// le
            {
                i++;
                if (a[x, y] == a[i, j])
                {
                    for (int k = x + 1; k < i; k++)
                    {
                        osszeg++;
                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }

            }
            i = x; j = y; t = 0;
            while (t == 0)  /// fel
            {

                i--;
                if (a[x, y] == a[i, j])
                {
                    for (int k = x - 1; k > i; k--)
                    {
                        osszeg++;
                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }

            }
            i = x; j = y; t = 0;
            while (t == 0)  /// jobbra
            {
                j++;
                if (a[x, y] == a[i, j])
                {
                    for (int k = y + 1; k < j; k++)
                    {
                        osszeg++;
                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }

            }
            i = x; j = y; t = 0;
            while (t == 0)  /// balra
            {
                j--;
                if (a[x, y] == a[i, j])
                {
                    for (int k = y - 1; k > j; k--)
                    {
                        osszeg++;
                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }
            }
            i = x; j = y; t = 0;
            while (t == 0)  /// slegan fel jobbra
            {
                j++;
                i--;
                if (a[x, y] == a[i, j])
                {
                    for (int k = y + 1, l = x - 1; k < j; k++, l--)
                    {
                        osszeg++;
                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }
            }
            i = x; j = y; t = 0;
            while (t == 0)  /// slegan fel balra
            {
                j--;
                i--;
                if (a[x, y] == a[i, j])
                {
                    for (int k = y - 1, l = x - 1; k > j; k--, l--)
                    {
                        osszeg++;
                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }
            }
            i = x; j = y; t = 0;
            while (t == 0)  /// slegan le jobbra
            {
                j++;
                i++;
                if (a[x, y] == a[i, j])
                {
                    for (int k = y + 1, l = x + 1; k < j; k++, l++)
                    {
                        osszeg++;
                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }
            }
            i = x; j = y; t = 0;
            while (t == 0)  /// slegan le balra
            {
                j--;
                i++;
                if (a[x, y] == a[i, j])
                {
                    for (int k = y - 1, l = x - 1; k > j; k--, l++)
                    {
                        osszeg++;
                    }
                }
                if (fajta != a[i, j])
                {
                    t = 1;
                }
            }
        }
        public void feketerak()
        {
            int vosszeg = 0, x3 = 0, y3 = 0, x2 = 0, y2 = 0, x4 = 0, y4 = 0,k1=1,k8=8;
            int jobb = 0, bal = 0, fent = 0, lent = 0, kjobb = 0, kbal = 0, kfent = 0, klent = 0;


            for (int i=1;i<9;i++)
            {
                for(int j=1;j<9;j++)
                {
                    
                    if(a[i,j]==0)
                    {
                        if((i==1&&j==1)||(i==8&&j==1)||(i==8&&j==8)||(i==1&&j==8)&&vosszeg==0)
                        {
                            x3 = i;
                            y3 = j;
                        }
                        x4 = i;
                        y4 = j;
                        if ((a[i+1,j]==0 &&a[i,j+1]==0 && a[i+1, j + 1] == 0 && a[i, j - 1] == 0 && a[i-1, j] == 0 && a[i-1, j + 1] == 0 && a[i-1, j - 1] == 0 && a[i+1, j - 1] == 0)&&x3==0)
                        {
                            
                            x2 = i;
                                y2 = j;
                        }
                        if ((a[i + 1, j] == 1 || a[i, j + 1] == 1 || a[i + 1, j + 1] == 1 || a[i, j - 1] == 1 || a[i - 1, j] == 1 || a[i - 1, j + 1] == 1 || a[i - 1, j - 1] == 1 || a[i + 1, j - 1] == 1) && x3 == 0 && x2 == 0)
                        {

                            x2 = i;
                            y2 = j;
                        }
                        a[i, j] = 2;
                        szamlalo(i,j,1);
                        a[i, j] = 0;
                        if(vosszeg<osszeg)
                        {
                            vosszeg = osszeg;
                            x3 = i;
                            y3 = j;
                        }
                    }
                }
            }
            if(x3==0)
            {
                for (int i = 1; i < 9; i++)
                {
                    if (a[1, i] == 1)
                    {
                        fent++;
                    }
                    else
                    if (a[1, i] == 2)
                    {
                        kfent++;
                    }
                    if (a[8, i] == 1)
                    {
                        lent++;
                    }
                    else
                    if (a[8, i] == 2)
                    {
                        klent++;
                    }
                    if (a[i, 8] == 1)
                    {
                        jobb++;
                    }
                    else
                    if (a[i, 8] == 2)
                    {
                        kjobb++;
                    }
                    if (a[i, 1] == 1)
                    {
                        bal++;
                    }
                    else
                    if (a[i, 1] == 2)
                    {
                        kbal++;
                    }
                }
                if ((kbal + bal) == 8 && (kjobb + jobb) == 8 && (klent + lent) == 8 && (kfent + fent) == 8)
                {
                    k1 = 2;
                    k8 = 7;
                }
                if (kbal > 0)
                {
                    int j = k1;
                    for (int i = k1; i <= k8; i++)
                    {
                        if (a[i, k1] == 0)
                        {
                            if (a[i + 1, j] == 2 || a[i, j + 1] == 2 || a[i + 1, j + 1] == 2 || a[i, j - 1] == 2 || a[i - 1, j] == 2 || a[i - 1, j + 1] == 2 || a[i - 1, j - 1] == 2 || a[i + 1, j - 1] == 2)
                            {
                                x3 = i;
                                y3 = k1;
                                break;
                            }
                        }
                    }
                }
                if ((jobb <= bal && kjobb > 0) || x3 == 0)
                {
                    int j = k8;
                    for (int i = k1; i <= k8; i++)
                    {
                        if (a[i, k8] == 0)
                        {
                            if (a[i + 1, j] == 2 || a[i, j + 1] == 2 || a[i + 1, j + 1] == 2 || a[i, j - 1] == 2 || a[i - 1, j] == 2 || a[i - 1, j + 1] == 2 || a[i - 1, j - 1] == 2 || a[i + 1, j - 1] == 2)
                            {
                                x3 = i;
                                y3 = k8;
                                break;
                            }
                        }
                    }
                }
                if ((fent <= jobb && fent <= bal && kfent > 0) || x3 == 0)
                {
                    int i = k1;
                    for (int j = k1; j <= k8; j++)
                    {
                        if (a[k1, j] == 0)
                        {
                            if (a[i + 1, j] == 2 || a[i, j + 1] == 2 || a[i + 1, j + 1] == 2 || a[i, j - 1] == 2 || a[i - 1, j] == 2 || a[i - 1, j + 1] == 2 || a[i - 1, j - 1] == 2 || a[i + 1, j - 1] == 2)
                            {
                                x3 = k1;
                                y3 = j;
                                break;
                            }
                        }
                    }
                }
                if ((lent <= bal && lent <= jobb && lent <= fent && klent > 0) || x3 == 0)
                {
                    int i = k8;
                    for (int j = k1; j <= k8; j++)
                    {
                        if (a[k8, j] == 0)
                        {
                            if (a[i + 1, j] == 2 || a[i, j + 1] == 2 || a[i + 1, j + 1] == 2 || a[i, j - 1] == 2 || a[i - 1, j] == 2 || a[i - 1, j + 1] == 2 || a[i - 1, j - 1] == 2 || a[i + 1, j - 1] == 2)
                            {
                                x3 = k8;
                                y3 = j;
                                break;
                            }
                        }
                    }
                }
            }
            else
            if(x3==0)
            {
                x3 = x2;
                y3 = y2;
            }
            if (x3 == 0)
            {
                x3 = x4;
                y3 = y4;
            }
            a[x3, y3] = 2;
            label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + 1);
            lista[(x3-1)*8+y3-1].BackgroundImage = fekete;
            lista[(x3 - 1) * 8 + y3 - 1].BackColor = Color.Red;
            nez(x3, y3, 1);
        }
        public void rak()
        {
            for(int i=0;i<64;i++)
            {
                    lista[i].BackColor = Color.Transparent;
            }
            int x = 0, y = 0;
                if(most%8==0)
                {
                    x = most / 8;
                }
                else
                x = most / 8+1;
                y = most - ((x-1) * 8);     
            a[x, y] = 1;
            lista[most-1].BackgroundImage = feher;
            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + 1);
            lista[most - 1].BackColor = Color.Red;
            nez(x,y,2);
            Task.Delay(1000).Wait();
            for (int i = 0; i < 64; i++)
            {
                lista[i].BackColor = Color.Transparent;
            }
            Task.Delay(500).Wait();
            feketerak();
            if(Convert.ToInt32(label2.Text)+ Convert.ToInt32(label1.Text)==64)
            {
                vege();
            }


        }
        public void vege()
        {
            for (int i = 0; i < 64; i++)
            {
                lista[i].BackColor = Color.Transparent;
            }
            label3.Visible = true;
            button1.Visible = true;
            if (Convert.ToInt32(label1.Text)> Convert.ToInt32(label2.Text))
            {
                label3.Text = "Sajnos vesztettél";
            }
            else
                if(Convert.ToInt32(label1.Text) < Convert.ToInt32(label2.Text))
            {
                label3.Text = "Gratulálok győztél";
            }
            else
                label3.Text="Hát ez döntetlen lett!";
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            most = 2;
            if(a[1, 2]==0)
            rak();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            most = 23;
            if (a[3, 7] == 0)
                rak();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            most = 13;
            if (a[2, 5] == 0)
                rak();
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            most = 64;
            if (a[8, 8] == 0)
                rak();
        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {
            most = 63;
            if (a[8, 7] == 0)
                rak();
        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {
            most = 62;
            if (a[8, 6] == 0)
                rak();
        }

        private void pictureBox61_Click(object sender, EventArgs e)
        {
            most = 61;
            if (a[8, 5] == 0)
                rak();
        }

        private void pictureBox60_Click(object sender, EventArgs e)
        {
            most = 60;
            if (a[8, 4] == 0)
                rak();
        }

        private void pictureBox59_Click(object sender, EventArgs e)
        {
            most = 59;
            if (a[8, 3] == 0)
                rak();
        }

        private void pictureBox58_Click(object sender, EventArgs e)
        {
            most = 58;
            if (a[8, 2] == 0)
                rak();
        }

        private void pictureBox57_Click(object sender, EventArgs e)
        {
            most = 57;
            if (a[8, 1] == 0)
                rak();
        }

        private void pictureBox56_Click(object sender, EventArgs e)
        {
            most = 56;
            if (a[7, 8] == 0)
                rak();
        }

        private void pictureBox55_Click(object sender, EventArgs e)
        {
            most = 55;
            if (a[7, 7] == 0)
                rak();
        }

        private void pictureBox54_Click(object sender, EventArgs e)
        {
            most = 54;
            if (a[7, 6] == 0)
                rak();
        }

        private void pictureBox53_Click(object sender, EventArgs e)
        {
            most = 53;
            if (a[7, 5] == 0)
                rak();
        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {
            most = 52;
            if (a[7, 4] == 0)
                rak();
        }

        private void pictureBox51_Click(object sender, EventArgs e)
        {
            most = 51;
            if (a[7, 3] == 0)
                rak();
        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {
            most = 50;
            if (a[7, 2] == 0)
                rak();
        }

        private void pictureBox49_Click(object sender, EventArgs e)
        {
            most = 49;
            if (a[7, 1] == 0)
                rak();
        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {
            most = 48;
            if (a[6, 8] == 0)
                rak();
        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {
            most = 47;
            if (a[6, 7] == 0)
                rak();
        }

        private void pictureBox46_Click(object sender, EventArgs e)
        {
            most = 46;
            if (a[6, 6] == 0)
                rak();
        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            most = 45;
            if (a[6, 5] == 0)
                rak();
        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {
            most = 44;
            if (a[6, 4] == 0)
                rak();
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            most = 43;
            if (a[6, 3] == 0)
                rak();
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            most = 42;
            if (a[6, 2] == 0)
                rak();
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            most = 41;
            if (a[6,1] == 0)
                rak();
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            most = 40;
            if (a[5, 8] == 0)
                rak();
        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            most = 39;
            if (a[5, 7] == 0)
                rak();
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            most = 38;
            if (a[5, 6] == 0)
                rak();
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            most = 37;
            if (a[5,5] == 0)
                rak();
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            most = 36;
            if (a[5, 4] == 0)
                rak();
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            most = 35;
            if (a[5, 3] == 0)
                rak();
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            most = 34;
            if (a[5, 2] == 0)
                rak();
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            most = 33;
            if (a[5, 1] == 0)
                rak();
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            most = 32;
            if (a[4, 8] == 0)
                rak();
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            most = 31;
            if (a[4, 7] == 0)
                rak();
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            most = 30;
            if (a[4, 6] == 0)
                rak();
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            most = 29;
            if (a[4, 5] == 0)
                rak();
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            most = 28;
            if (a[4, 4] == 0)
                rak();
        }

        private void pictureBox277_Click(object sender, EventArgs e)
        {
            most = 27;
            if (a[4, 3] == 0)
                rak();
        }

        private void pictureBox26_Click_1(object sender, EventArgs e)
        {
            most = 26;
            if (a[4, 2] == 0)
                rak();
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            most = 25;
            if (a[4, 1] == 0)
                rak();
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            most = 24;
            if (a[3, 8] == 0)
                rak();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            most = 21;
            if (a[3, 5] == 0)
                rak();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            most = 20;
            if (a[3, 4] == 0)
                rak();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            most = 19;
            if (a[3, 3] == 0)
                rak();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            most = 18;
            if (a[3, 2] == 0)
                rak();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            most = 17;
            if (a[3, 1] == 0)
                rak();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            most = 16;
            if (a[2, 8] == 0)
                rak();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            most = 15;
            if (a[2, 7] == 0)
                rak();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            most = 14;
            if (a[2, 6] == 0)
                rak();
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            most = 22;
            if (a[3, 6] == 0)
                rak();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            most = 12;
            if (a[2, 4] == 0)
                rak();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            most = 11;
            if (a[2, 3] == 0)
                rak();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            most = 10;
            if (a[2, 2] == 0)
                rak();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            most = 9;
            if (a[2, 1] == 0)
                rak();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            most = 8;
            if (a[1, 8] == 0)
                rak();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            most = 7;
            if (a[1, 7] == 0)
                rak();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            most = 6;
            if (a[1, 6] == 0)
                rak();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            most = 5;
            if (a[1, 5] == 0)
                rak();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            most = 4;
            if (a[1, 4] == 0)
                rak();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            most = 3;
            if (a[1, 3] == 0)
                rak();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            most = 1;
            if (a[1, 1] == 0)
                rak();
        }
    }
}
