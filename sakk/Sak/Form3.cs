using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sak
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader(@"C:\Users\hjano\OneDrive\Desktop\sakk\Eredmeny.txt"); // Beolvassa a fájlt 

            List<string> nevek = new List<string>();
            List<int> gyozelmek = new List<int>();
            while (!sr.EndOfStream)
            {
                string[] darabok = sr.ReadLine().Split(':');
                nevek.Add(darabok[0]);
                gyozelmek.Add(Convert.ToInt32(darabok[1][1])-48);
            }
            sr.Close();
            StreamWriter sw = new StreamWriter(@"C:\Users\hjano\OneDrive\Desktop\sakk\Eredmeny.txt", false, Encoding.Default);
            string a="sasa";
            if (Form1.ido == 1)
            {
                if (Form1.hido == 0)
                {
                    label1.Text = "Gratulálok " + Form4.knev + "  játékosnak";
                    label3.Text = "Lejárt az ido " + Form4.hnev;
                    a = Form4.knev;
                }
                else
                    if (Form1.kido == 0)
                {
                    label1.Text = "Gratulálok " + Form4.hnev + "  játékosnak";
                    label3.Text = "Lejárt az ido " + Form4.knev;
                    a = Form4.hnev;
                }
            }
            else
            if (Form1.hk == 0)
            {
                label1.Text = "Gratulálok " + Form4.knev + "  játékosnak";
                a = Form4.knev;
            }
            else
            {
                label1.Text = "Gratulálok " + Form4.hnev + "  játékosnak";
                a = Form4.hnev;
            }
            
                if(Form1.feladas==1)
            {
                if (Form1.hk == 0)
                {
                    label3.Text = "Sajnálom hogy feladtad "+ Form4.hnev;
                    }
                else
                {
                    label3.Text = "Sajnálom hogy feladtad " + Form4.knev;
                }
            }
            if(Form1.sakmatt==1)
            {
                label3.Text = "Ez egy gyönyörü sakk-matt volt";
            }
            int nev2 = nevek.IndexOf(a);
            if (nev2 == -1)
            {
                nevek.Add(a);
                gyozelmek.Add(1);
            }
            else
            {
                gyozelmek[nev2]++;
            }
            for(int i = 0; i < nevek.Count; i++)
            {
                for (int j = i+1; j < nevek.Count; j++)
                {
                    if(gyozelmek[i]<gyozelmek[j])
                    {
                        int t = gyozelmek[i];
                        gyozelmek[i] = gyozelmek[j];
                        gyozelmek[j] = t;
                        string nev = nevek[i];
                        nevek[i] = nevek[j];
                        nevek[j] = nev;
                    }
                }
            }
            for(int i=0;i<nevek.Count;i++)
                {
                sw.Write(nevek[i]);
                sw.WriteLine(": " + Convert.ToString(gyozelmek[i]));
            }
            sw.Flush();
            sw.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
