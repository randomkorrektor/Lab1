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
    public partial class FormQuestion : Form
    {
        public int reqest=0;

        public FormQuestion(string mess)
        {
            InitializeComponent();
            richTextBox1.Text = mess;
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            reqest = 1;
            this.Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            reqest = 2;
            this.Close();
        }
    }
}
