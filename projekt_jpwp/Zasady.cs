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
    public partial class Zasady : UserControl
    {
        /// <summary>
        /// zasady gry
        /// </summary>
        public Zasady()
        {
            InitializeComponent();
        }

        /// <summary>
        /// powrót do menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
