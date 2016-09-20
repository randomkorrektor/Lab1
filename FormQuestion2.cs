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
    public partial class FormQuestion2 : Form
    {
        public bool sure = false;
        public FormQuestion2(string mess)
        {
            InitializeComponent();
            richTextBox1.Text = mess;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sure = true;
            this.Close();
        }
    }
}
