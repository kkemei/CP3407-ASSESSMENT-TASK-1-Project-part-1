using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wilderness_Weather_Station
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnS1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home S1 = new Home("Townsville",1);
            S1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home S1 = new Home("New York",2);
            S1.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home S1 = new Home("Rio de Janeiro",3);
            S1.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home S1 = new Home("Nairobi",4);
            S1.ShowDialog();
            this.Close();
        }
    }
}
