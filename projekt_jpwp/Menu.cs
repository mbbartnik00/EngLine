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

    public partial class Menu : Form
    {
        /// <summary>
        /// menu główne
        /// </summary>
        public Menu()
        {
            InitializeComponent();
            userControl11.Hide();
            
        }

        /// <summary>
        /// rozpoczęcie gry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e) 
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
        }
        /// <summary>
        /// zasady gry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            userControl11.Show();
        }
        /// <summary>
        ///  wyjście z gry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
