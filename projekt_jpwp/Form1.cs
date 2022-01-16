using System;
using System.Threading;
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
        ///@{
        /** zmienna potrzebne do działania timera */
        static int minuta2;
        static int sekunda2;
        public static int minuta;
        public static int sekunda;
        ///@}

        ///@{
        /** zmienna wspierająca działanie timera */
        public static bool sprawdz = false;
        ///@}
        ///@{
        /** zmienna przesyłające informacje o słowach */
        string zdanie; string zdanie2; int q;int w;int f;int r;int t;int y;int o; int odstep = 3; int ilosc; int zdania;
        ///@}
        ///@{
        /** gate'y zmieniające swoją wartość w określonych przypadkach */
        int g1;int g2; int g3; int g4;int g5; int g6; int gate = 0; 
        ///@}

        /// plansza gry
        public Form1()
        {
            InitializeComponent();
            sprawdz = false;
            StartPosition = FormStartPosition.CenterScreen;
            userControl21.Hide();
            listBox1.AllowDrop = true;
            listBox2.AllowDrop = true;
            listBox1.Visible = false;
            listBox2.Visible = false;
            button42.Visible = false;
            label7.Visible = false;
            listBox1.MultiColumn = true;
            odstep = 2;
            wpisywanie(new string[6] { "sometimes", "angry", "is", "my", "very", "dog" }, 2, 9, 5, 2, 2, 4, 3, 6);
            labels(6, "pies", "jest", "mój", "czasami", "zły", "bardzo");
            zdanie = "my dog is sometimes very angry ";
            zdanie2 = "sometimes my dog is very angry ";
            listBox1.Items.AddRange(new object[] { "dog", "very", "my", "sometimes", "is", "angry" });
            listBox3.Items.AddRange(listBox1.Items);


        }

        /// <summary>
        /// losowanie liter wpisywanych do ciągu
        /// </summary>
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
        /// <summary>
        /// wpisywanie słów do ciągu
        /// </summary>
        /// <param name="zdanie"></param>
        /// <param name="x"></param>
        /// <param name="c"></param>
        /// <param name="v"></param>
        /// <param name="b"></param>
        /// <param name="n"></param>
        /// <param name="l"></param>
        /// <param name="k"></param>
        /// <param name="zd"></param>
        public void wpisywanie(string[] zdanie, int x, int c, int v, int b, int n, int l, int k,int zd) //wpisywanie wyrazów do ciągu
        {
            q = x;w = c;f = v; r = b;t = n;y = l;o = k;
            zdania = zd;
            TableLayoutControlCollection controls1 = tableLayoutPanel1.Controls;
            losowanie();
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
        /// <summary>
        /// wpisywanie słów do label'ów i ich wyświetlanie
        /// </summary>
        /// <param name="z"></param>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <param name="l3"></param>
        /// <param name="l4"></param>
        /// <param name="l5"></param>
        /// <param name="l6"></param>
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
                label6.Text = l4;
                label6.Visible = true;
            }
            if (z == 5 || z > 5)
            {
                label5.Text = l5;
                label5.Visible = true;
            }
            if(z==6)
            {
                label8.Text = l6;
                label8.Visible = true;
            }
            if (label2.Text == "x")
            {
                label6.Visible = false;
            }
            if (label3.Text == "x")
            {
                label3.Visible = false;
            }
            if (label4.Text == "x")
            {
                label4.Visible = false;
            }
            if (label6.Text == "x")
            {
                label6.Visible = false;
            }
            if (label5.Text == "x")
            {
            label5.Visible = false;
            }
            if (label8.Text == "x")
            {
                label8.Visible = false;
            }


        }

        /// <summary>
        /// wybór litery przez gracza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e) 
        {
            var theButton = (Button)sender;
            theButton.BackColor = Color.Yellow;
        }
        /// <summary>
        /// sprawdzanie czy wybrana litera przez gracza jest zawarta w słowie
        /// </summary>
        /// <returns></returns>
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
            for (int i = q + w + f + r + t+y+4 * odstep; i < q + w + f + r + t + y + 5 * odstep; i++)
            {
                if (controls1[i].BackColor == Color.Yellow)
                {
                    return true;
                }
            }
            for (int i = q + w + f + r + t + y +o+ 5 * odstep; i < 40; i++)
            {
                if (controls1[i].BackColor == Color.Yellow)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// przygotowanie do kolejnego przykładu
        /// </summary>
        private void reset() 
        {
            listBox1.Visible = false;
            listBox2.Visible = false;
            tableLayoutPanel1.Visible = true;
            TableLayoutControlCollection controls1 = tableLayoutPanel1.Controls;
            for (int i = 0; i < 40; i++)
            {
                if (controls1[i] is Button)
                {
                    controls1[i].Visible = true;
                }
            }
            losowanie();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
        }
        /// <summary>
        /// sprawdzenie poprawności zaznaczonego słowa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            int temp = 0;
            for (int i = 0; i < 40; i++)
                if (controls1[i].BackColor == Color.Yellow)
                {
                    temp++;
                }
            int licznik = 0; int licznik1 = 0;int licznik2 = 0; int licznik3 = 0; int licznik4 = 0; int licznik5 = 0;
            
            for (int i = q; i < w + q; i++)
                if (controls1[i].BackColor == Color.Yellow) licznik++;
            for (int i = q; i < w + q; i++)
            {
                if (controls1[i].BackColor == Color.Yellow && licznik==w && temp == w)
                {
                    controls1[i].Visible = false;
                    g1 = 1;
                } else controls1[i].BackColor = Color.Gainsboro;
            } if (g1 == 1) { zdania--; g1 = 2; }
            for (int i = q + w + odstep; i < q + w + odstep + f; i++)
                if (controls1[i].BackColor == Color.Yellow) licznik1++;
            for (int i=q+w+odstep; i < q + w + odstep+f; i++)
            {
                if (controls1[i].BackColor == Color.Yellow && licznik1==f && temp==f)
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
                
                if (controls1[i].BackColor == Color.Yellow && (ilosc==3 || ilosc > 3) && licznik2==r && temp == r)
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
                if (controls1[i].BackColor == Color.Yellow && (ilosc == 4 || ilosc > 4) && licznik3==t && temp == t)
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
                if (controls1[i].BackColor == Color.Yellow && (ilosc == 5 || ilosc > 5) && licznik4==y && temp == y)
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
                if (controls1[i].BackColor == Color.Yellow && ilosc == 6 && licznik5==o && temp == o)
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
                tableLayoutPanel1.Visible = false;
                g1 = 0; g2 = 0;g3 = 0;g4 = 0;g5 = 0;g6 = 0;
            }

        }


        /// <summary>
        /// funkcja obsługująca przeciąganie słów między listami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            listBox2.DoDragDrop(listBox1.SelectedItem.ToString(), DragDropEffects.Copy);
        }
        /// <summary>
        /// funkcja obsługująca przeciąganie słów między listami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else e.Effect = DragDropEffects.None;
        }
        /// <summary>
        /// funkcja obsługująca przeciąganie słów między listami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            listBox2.Items.Add(e.Data.GetData(DataFormats.Text));
            listBox1.Items.Remove(e.Data.GetData(DataFormats.Text));
        }

        /// <summary>
        /// sprawdzanie poprawności ułożonego zdania
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button42_Click_1(object sender, EventArgs e)
        {
            StringBuilder stringB = new StringBuilder();
            foreach (var item in listBox2.Items)
            {
                stringB.Append(item.ToString());
                stringB.Append(" ");
            }

            if (zdanie == stringB.ToString() || zdanie2 == stringB.ToString())
            {
                
                gate++;
                if (gate == 1)
                {
                    sekunda = sekunda2;
                    minuta = minuta2;
                    
                    reset();
                    odstep = 3;
                    wpisywanie(new string[5] { "milk", "he", "drink", "day", "twice" }, 3, 4, 2, 5, 3, 5, 0, 5);
                    labels(6, "mleko", "on", "pić", "dzień", "dwa razy", "x");
                    zdanie = "he drinks milk twice a day ";
                    listBox1.Items.AddRange(new object[] { "drinks", "he", "twice", "milk", "day", "a" });
                    listBox3.Items.AddRange(listBox1.Items);
                    

                }
                if (gate == 2)
                {
                    sekunda = sekunda2;
                    minuta = minuta2;
                    reset();
                    odstep = 4;
                    wpisywanie(new string[4] { "enjoy", "piano", "play", "she" }, 2, 5, 5, 4, 3, 0, 0, 4);
                    labels(6, "lubić", "ona", "pianino", "grać", "x", "x");
                    zdanie = "she enjoys playing the piano ";              
                    listBox1.Items.AddRange(new object[] { "piano", "enjoys", "the", "playing", "she" });
                    listBox3.Items.AddRange(listBox1.Items);

                }
                if (gate == 3)
                {
                    sprawdz = true;
                    sekunda = 0; sekunda2 = 0; minuta = 0; minuta2 = 0;
                    timer1.Stop();
                    userControl21.Show();
                }
            }
            else
            {
                listBox2.Items.Clear();
                listBox1.Items.Clear();
                listBox1.Items.AddRange(listBox3.Items);
            }
        }
        /// <summary>
        /// powrót do menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button43_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            sekunda = 0; sekunda2 = 0; minuta = 0; minuta2 = 0;
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
             
        }
        /// <summary>
        /// timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e) 
        {
            
            if (sprawdz == true)
            {
                label10.Visible = false;

            }
            sekunda2++;
                if (sekunda2 == 60)
                {
                    minuta2++;
                    sekunda2 = 0;
                    label10.Text = minuta2.ToString() + " : " + sekunda2.ToString();
                }
            if (sprawdz == true)
            {
                label10.Visible = false;
            }
            
            label10.Text = minuta2.ToString() + " : " + sekunda2.ToString();

        }
    }
}
