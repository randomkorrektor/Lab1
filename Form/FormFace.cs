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

    public partial class FormFace : Form
    {
        private EmployeesBase EmpBase = new EmployeesBase();

        public FormFace()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = EmpBase.employees[listBox1.SelectedIndex].GetData();
        }

        private void RefrashAll()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < EmpBase.employees.Count; i++)
            {
                listBox1.Items.Add(EmpBase.employees[i].name);
            }
            listBox1.Refresh();
            listBoxStaff.Items.Clear();
            for (int i = 0; i < EmpBase.staff.Count; i++)
            {
                listBoxStaff.Items.Add(EmpBase.staff[i].name);
            }
            listBoxStaff.Refresh();
            richTextBox1.Clear();
            comboBoxPO.Items.Clear();
            comboBoxSM.Items.Clear();
            comboBoxTeam.Items.Clear();
            comboBoxPO.Text = "";
            comboBoxSM.Text = "";
            comboBoxTeam.Text = "";
            for (int i = 0; i < EmpBase.ListPO.Count; i++)
            {
                comboBoxPO.Items.Add(EmpBase.ListPO[i].name);
            }
            for (int i = 0; i < EmpBase.ListSM.Count; i++)
            {
                comboBoxSM.Items.Add(EmpBase.ListSM[i].name);
            }
            for (int i = 0; i < EmpBase.ListTeams.Count; i++)
            {
                comboBoxTeam.Items.Add(EmpBase.ListTeams[i].name);
            }
            comboBoxSM.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Init = new FormInitialization();
            Init.ShowDialog();
            if (Init.name != null && Init.function != null)
            {
                EmpBase.AddEmployee(Init.name, Init.function);
                listBox1.Items.Add(Init.name);
                RefrashAll();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                FormLeveling lev = new FormLeveling(EmpBase.employees[listBox1.SelectedIndex]);
                lev.ShowDialog();
                richTextBox1.Text = EmpBase.employees[listBox1.SelectedIndex].GetData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                EmpBase.DelEmployee(listBox1.SelectedIndex);
                RefrashAll();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Streamer.ReadFile(EmpBase.employees);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (EmpBase.employees.Count > 0)
            {
                string mess = "This database includes employees. Clear base?";
                var warning = new FormQuestion(mess);
                warning.ShowDialog();
                switch (warning.reqest)
                {
                    case 1:
                        EmpBase.employees.Clear();
                        listBox1.Items.Clear();
                        Streamer.WriteFile(EmpBase);
                        break;
                    case 2:
                        listBox1.Items.Clear();
                        Streamer.WriteFile(EmpBase);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Streamer.WriteFile(EmpBase);
                
            }
            RefrashAll();
        }

        private void buttonAppoint_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                var af = new FormAF();
                af.ShowDialog();
                EmpBase.AlterFuncEmployee(listBox1.SelectedIndex, af.function);
            }
            richTextBox1.Clear();
            RefrashAll();
        }

        private void comboBoxTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = EmpBase.ListTeams[comboBoxTeam.SelectedIndex].GetData();
        }

        private void comboBoxPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = EmpBase.ListPO[comboBoxPO.SelectedIndex].GetData();
        }

        private void comboBoxSM_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = EmpBase.ListPO[comboBoxPO.SelectedIndex].GetData();
        }

        private void buttonStaffIn_Click(object sender, EventArgs e)
        {
            if (comboBoxPO.Text != "" && comboBoxSM.Text != "" && comboBoxTeam.Text != "")
            {
                EmpBase.BuildStaff(comboBoxPO.SelectedIndex, comboBoxTeam.SelectedIndex, comboBoxSM.SelectedIndex);
                RefrashAll();
            }
        }
    }

}
