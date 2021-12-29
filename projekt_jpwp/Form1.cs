using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static projekt_jpwp.Menu;
using System.Windows.Forms;

namespace projekt_jpwp
{
    public partial class Form1 : Form
    {
        int q;int w;int f;int r;int t;int y;int o; int odstep = 3; int ilosc; int zdania; int g1;int g2; int g3; int g4;int g5; int g6; int gate = 0;
        public Form1()
        {
            InitializeComponent();
            listBox1.AllowDrop = true;
            listBox2.AllowDrop = true;
            listBox1.Visible = false;
            listBox2.Visible = false;
            button42.Visible = false;
            label7.Visible = false;
            losowanie();
            //wpisywanie(new string[5] { "milk", "he", "drink", "day", "twice" }, 3, 4, 2, 5, 3, 5, 0,5);
            wpisywanie(new string[4] { "lubie", "placki", "bardzo", "tak" }, 3, 5, 6, 6, 3, 0, 0,4);
            labels(5, "mleko", "on", "pije", "dzień", "dwa razy","x");

            listBox1.MultiColumn = true; 
            listBox1.Items.AddRange(new object[] { "ja", "lubie", "placki", "bardzo"});
            this.Controls.Add(listBox1);
            
        }


        public void losowanie()
        {
            Random rnd = new Random();
            char randomChar = (char)rnd.Next('a', 'z');
            TableLayoutControlCollection controls1 = tableLayoutPanel1.Controls;
            for (int i = 0; i < 40; i++)
            {
                if (controls1[i] is Button)
                {
                    controls1[i].Text = randomChar.ToString();
                    char randomChar2 = (char)rnd.Next('a', 'z');
                    randomChar = randomChar2;

                }
            }
        }
        public void wpisywanie(string[] zdanie, int x, int c, int v, int b, int n, int l, int k,int zd)
        {
            q = x;w = c;f = v; r = b;t = n;y = l;o = k;
            zdania = zd;
            TableLayoutControlCollection controls1 = tableLayoutPanel1.Controls;
            for (int i = 0; i < zdanie.Length; i++)
            {
                char[] chars = zdanie[i].ToCharArray();
                for (int j = 0; j < chars.Length; j++)
                {
                    controls1[x].Text = chars[j].ToString();
                    x++;
                }
                x = x + odstep;
            }
        }

        private void labels(int z,string l1, string l2, string l3, string l4, string l5, string l6)
        {
            ilosc = z;
            if(z==3 || z > 3)
            {
                label2.Text = l1;
                label3.Text = l2;
                label4.Text = l3;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
            }
            if( z==4 || z > 4)
            {
                label5.Text = l4;
                label5.Visible = true;
            }
            if (z == 5)
            {
                label6.Text = l5;
                label6.Visible = true;
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            var theButton = (Button)sender;
            theButton.BackColor = Color.Yellow;
        }

        private bool blad()
        {
            TableLayoutControlCollection controls1 = tableLayoutPanel1.Controls;
            for (int i = 0; i < q; i++)
            {
                if (controls1[i].BackColor == Color.Yellow)
                {
                    return true;
                }
            }
            for (int i = q+w; i < q+w+odstep; i++)
            {
                if (controls1[i].BackColor == Color.Yellow)
                {
                    return true;
                }
            }
            for (int i = q + w+f+odstep; i < q + w + f+2*odstep; i++)
            {
                if (controls1[i].BackColor == Color.Yellow)
                {
                    return true;
                }
            }
            for (int i = q + w + f + r+2*odstep; i < q + w + f + r+3 * odstep; i++)
            {
                if (controls1[i].BackColor == Color.Yellow)
                {
                    return true;
                }
            }
            for (int i = q + w + f + r+t+3*odstep; i < q + w + f + r+t+4 * odstep; i++)
            {
                if (controls1[i].BackColor == Color.Yellow)
                {
                    return true;
                }
            }
            for (int i = q + w + f + r + t+y+4 * odstep; i < q + w + f + r + t+y+ 5 * odstep; i++)
            {
                if (controls1[i].BackColor == Color.Yellow)
                {
                    return true;
                }
            }
            return false;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            TableLayoutControlCollection controls1 = tableLayoutPanel1.Controls;
            if(blad())
            {
                for (int i = 0; i < 40; i++)
                {
                    if (controls1[i] is Button && controls1[i].BackColor==Color.Yellow)
                    {
                        controls1[i].BackColor = Color.Gainsboro;
                    }
                }
            }
            int licznik = 0; int licznik1 = 0;int licznik2 = 0; int licznik3 = 0; int licznik4 = 0; int licznik5 = 0;
            
            for (int i = q; i < w + q; i++)
                if (controls1[i].BackColor == Color.Yellow) licznik++;
            for (int i = q; i < w + q; i++)
            {
                if (controls1[i].BackColor == Color.Yellow && licznik==w)
                {
                    controls1[i].Visible = false;
                    g1 = 1;
                } else controls1[i].BackColor = Color.Gainsboro;
            } if (g1 == 1) { zdania--; g1 = 2; }
            for (int i = q + w + odstep; i < q + w + odstep + f; i++)
                if (controls1[i].BackColor == Color.Yellow) licznik1++;
            for (int i=q+w+odstep; i < q + w + odstep+f; i++)
            {
                if (controls1[i].BackColor == Color.Yellow && licznik1==f)
                {
                    controls1[i].Visible = false;
                    g2 = 1;
                } else controls1[i].BackColor = Color.Gainsboro;
            }
            if (g2 == 1) { zdania--; g2 = 2; }

            for (int i = q + w + f + (2 * odstep); i < q + w + (2 * odstep) + f + r; i++)
            {

                if (controls1[i].BackColor == Color.Yellow) licznik2++;
            }

            for (int i = q + w + f+(2*odstep); i < q + w + (2*odstep) + f+r; i++)
            {
                
                if (controls1[i].BackColor == Color.Yellow && (ilosc==3 || ilosc > 3) && licznik2==r)
                {
                    controls1[i].Visible = false;
                    g3 = 1;
                } else controls1[i].BackColor = Color.Gainsboro;
            }
            if (g3 == 1 ) { zdania--; g3= 3; }

            for (int i = q + w + f + r + 3 * odstep; i < q + w + 3 * odstep + f + r + t; i++)
                if (controls1[i].BackColor == Color.Yellow) licznik3++;
            for (int i = q + w + f + r + 3 * odstep; i < q + w + 3 * odstep + f + r + t; i++)
            {
                if (controls1[i].BackColor == Color.Yellow && (ilosc == 4 || ilosc > 4) && licznik3==t)
                {
                    controls1[i].Visible = false;
                    g4 = 1;
                } else controls1[i].BackColor = Color.Gainsboro;
            }
            if (g4 == 1) { zdania--; g4 = 3; }
            for (int i = q + w + f + r + t + 4 * odstep; i < q + w + 4 * odstep + f + r + t + y; i++)
                if (controls1[i].BackColor == Color.Yellow) licznik4++;
            for (int i = q + w + f + r + t +4 * odstep; i < q + w + 4 * odstep + f + r + t+y; i++)
            {
                if (controls1[i].BackColor == Color.Yellow && (ilosc == 5 || ilosc > 5) && licznik4==y)
                {
                    controls1[i].Visible = false;
                    g5 = 1;
                } else controls1[i].BackColor = Color.Gainsboro;
            }
            if (g5 == 1) { zdania--; g5 = 5; }
            for (int i = q + w + f + r + t + y + 5 * odstep; i < q + w + 5 * odstep + f + r + t + y + o; i++)
                if (controls1[i].BackColor == Color.Yellow) licznik5++;
            for (int i = q + w + f + r + t +y+ 5 * odstep; i < q + w + 5 * odstep + f + r + t + y+o; i++)
            {
                if (controls1[i].BackColor == Color.Yellow && ilosc == 6 && licznik5==o)
                {
                    controls1[i].Visible = false;
                    g6 = 1;
                } else controls1[i].BackColor = Color.Gainsboro;
            }
            if (g6 == 1) { zdania--; g6 = 6; }
            for (int i = 0; i < 40; i++)
            {
                if (controls1[i] is Button && controls1[i].BackColor == Color.Yellow)
                {
                    controls1[i].BackColor = Color.Gainsboro;
                }
            }
            if(zdania == 0)
            {
                listBox1.Visible = true;
                listBox2.Visible = true;
                button42.Visible = true;
                label7.Visible = true;
                g1 = 0; g2 = 0;g3 = 0;g4 = 0;g5 = 0;g6 = 0;
            }

        }

        private void button42_Click(object sender, EventArgs e)
        {
            string stringA = "ja lubie placki bardzo ";
            StringBuilder stringB = new StringBuilder();
            foreach (var item in listBox2.Items)
            {
                stringB.Append(item.ToString());
                stringB.Append(" ");
            }
            MessageBox.Show(stringA);
            MessageBox.Show(stringB.ToString());
            if(stringA == stringB.ToString())
            {
                MessageBox.Show("dziala");
            } else MessageBox.Show("nie dziala");
        }


        public void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            listBox2.DoDragDrop(listBox1.SelectedItem.ToString(), DragDropEffects.Copy);
        }

        public void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else e.Effect = DragDropEffects.None;
        }

        public void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            listBox2.Items.Add(e.Data.GetData(DataFormats.Text));
            listBox1.Items.Remove(e.Data.GetData(DataFormats.Text));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
