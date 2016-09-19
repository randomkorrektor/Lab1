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
    public partial class FormCreateContract : Form
    {
        

        public FormCreateContract()
        {
            InitializeComponent();
        }
        public string name, specification;
        public int workload, timeLimit;
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && richTextBox1.Text != "")
            {
                name = textBox1.Text;
                specification = richTextBox1.Text;
                workload = trackBar2.Value;
                timeLimit = trackBar1.Value;
                this.Close();
            }
            else
                MessageBox.Show("Enter the name and specification!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
