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
    public partial class FormScrum : Form
    {
        EmployeesBase EmpBase = new EmployeesBase();
        Contract contract;
        Scrum scrum = new Scrum();
        public bool end = false;

        public FormScrum(EmployeesBase empBase, Contract cont)
        {
            InitializeComponent();
            EmpBase = empBase;
            contract = cont;
            richTextBox1.Text = empBase.staff[0].function.ToString() + ": " + empBase.staff[0].name + "\n" + empBase.staff[1].function.ToString() + ": "
                + empBase.staff[1].name + "\n" + empBase.staff[2].function.ToString() + ": " + empBase.staff[2].name;
            richTextBox2.Text = "Name:\n" + cont.name + "\n\nSpecification:\n" + cont.specification;
            richTextBox3.Text = "Curret workload = "+ cont.workload+"\nCurrent timelimit = " + cont.timeLimit+" days";
        }

        private void RefreshInfo()
        {
            richTextBox3.Text = "Curret workload = " + scrum.productBL.workload + "\nCurrent timelimit = " + scrum.productBL.timeLimit + " days";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scrum.GenerateProductBL(EmpBase, contract);
            richTextBox4.Text = "Backlog generated.\n\nThanks to the prouct owner's skills workload reduced on " + scrum.productBL.POWorkload.ToString() + " and timelimit increased on" +
                scrum.productBL.POTime.ToString() + " days.";
            RefreshInfo();

            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scrum.GenerateSprintBL(EmpBase);
            richTextBox4.Text = "Sprint backlog generated.\n\nDuration of the sprint = " + scrum.sprintBL.timeLimit + " day's.\n\nPlanned workload = " + scrum.sprintBL.workload + ".";

            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (scrum.productBL.timeLimit > scrum.sprintBL.timeLimit)
            {
                scrum.productBL.timeLimit -= scrum.sprintBL.timeLimit;
                scrum.Sprint(EmpBase);
                if (scrum.work >= scrum.sprintBL.workload)
                {
                    if (scrum.productBL.workload - scrum.work > 0)
                    {
                        scrum.productBL.workload -= scrum.work;
                        richTextBox4.ForeColor = Color.Green;
                        richTextBox4.Text = "Sprint success!\nCurrent workload reduced on" + scrum.work.ToString() + ".";
                        if(scrum.reiterative>0)
                            scrum.reiterative = -20;
                        button3.Enabled = false;
                        button2.Enabled = true;
                        RefreshInfo();
                    }
                    else
                    {
                        scrum.productBL.workload = 0;
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button2.Enabled = false;
                        MessageBox.Show("Contract is finished!");
                        RefreshInfo();
                        richTextBox4.ForeColor = Color.Green;
                        end = true;
                    }
                }
                else
                {
                    richTextBox4.Text = "Sprint unsuccess!\n\nStaff was not able to perform the tasks. We need a new sprint backlog.";
                    scrum.productBL.workload -= scrum.work/2;
                    scrum.reiterative +=20;
                    button3.Enabled = false;
                    button2.Enabled = true;
                    richTextBox4.ForeColor = Color.Red;
                    RefreshInfo();
                }


            }
            else
            {
                MessageBox.Show("Time limit was exceeded!\nContract is failed.");
                button1.Enabled = false;
                button3.Enabled = false;
                button2.Enabled = false;
                richTextBox4.ForeColor = Color.Red;
                end = true;
                richTextBox4.Text = "Time limit was exceeded!\nContract is failed.";
                scrum.productBL.timeLimit = 0;
                RefreshInfo();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (end)
            {
                this.Close();
            }
            else
            {
                string mess = "This action interrupts scrum/nAre you sure?";
                FormQuestion2 fq = new FormQuestion2(mess);
                fq.ShowDialog();
                if (fq.sure)
                    this.Close();
            }
        }
        //richTextBox1.ForeColor = Color.Red;


    }
}
