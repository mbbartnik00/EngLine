using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt_jpwp
{
    public partial class Koniec : UserControl
    {

        int sekunda2; int minuta2;
        /// <summary>
        /// ekran końcowy gry
        /// </summary>
        public Koniec()
        {
            InitializeComponent();
            timer1.Start();
            
                  
        }
        /// <summary>
        /// powrót do menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) 
        {
            Menu menu = new Menu();
            timer1.Stop();
            timer1.Dispose();
            this.Hide();
            Form tmp = this.FindForm();
            tmp.Close();
            tmp.Dispose();
            menu.ShowDialog();
        }
        /// <summary>
        /// timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick_1(object sender, EventArgs e) 
        {
            if (Form1.sprawdz)
            {
                timer1.Stop();
            }
            label2.Visible = true;
            sekunda2++;
            if (sekunda2 == 60)
            {
                minuta2++;
                sekunda2 = 0;
                
                label2.Text = "Czas gry: " + minuta2.ToString() + " : " + sekunda2.ToString();
            }           
            label2.Text = "Czas gry: " + minuta2.ToString() + " : " + sekunda2.ToString();
            
        }
    }
}
