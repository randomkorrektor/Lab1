using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormAF : Form
    {
        public string function;
        public FormAF()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "Product owner", "Scrum master", "Team" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                function = comboBox1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Select function");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
