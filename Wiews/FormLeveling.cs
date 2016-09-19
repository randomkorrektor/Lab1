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
    public partial class FormLeveling : Form
    {
        Employee student = new Employee();
        protected int freePoints = 5;
        public int lead=0,resp=0,prog=0,dip=0;


        public FormLeveling(Employee stud)
        {
            InitializeComponent();
            student = stud;
        }

        private void FormLeveling_Load(object sender, EventArgs e)
        {
            labelName.Text += student.name;
            labelFunction.Text += student.function;
            labelLvl.Text += student.lvl;
            RefreshAll();
        }

        private void RefreshAll()
        {
            labelLeadership.Text = "Leadership: "+(student.leadership+lead);
            labelResponsibility.Text = "Responsibility: "+(student.responsibility+resp);
            labelProgramming.Text = "Programming: "+(student.programming+prog);
            labelDiplomacy.Text = "Designe: "+(student.diplomacy+dip);
            labelPoints.Text = "Free points: "+freePoints;
            labelLid.Text = lead.ToString();
            labelProg.Text = prog.ToString();
            labelResp.Text = resp.ToString();
            labelDes.Text = dip.ToString();

        }

        private int ButUp(int characterictic, int num)
        {
            if (freePoints > 0 && characterictic + num + 1 < 101)
            {
                num++;
                freePoints--; 
            }
            return (num);
        }

        private int ButDown(int characterictic, int num)
        {
            if (freePoints < 5 && num>0)
            {
                num--;
                freePoints++;
            }
            return (num);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lead = ButDown(student.leadership, lead);
            RefreshAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lead = ButUp(student.leadership, lead);
            RefreshAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            resp = ButDown(student.responsibility, resp);
            RefreshAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            resp = ButUp(student.responsibility, resp);
            RefreshAll();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            prog = ButDown(student.programming, prog);
            RefreshAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            prog = ButUp(student.programming, prog);
            RefreshAll();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dip = ButDown(student.diplomacy, dip);
            RefreshAll();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dip = ButUp(student.diplomacy, dip);
            RefreshAll();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (freePoints > 0)
                MessageBox.Show("You have " + freePoints.ToString() + " free points!");
            else
            {
                student.LvlUp(lead, resp, prog, dip);
                this.Close();
            }
        }


    }
}
