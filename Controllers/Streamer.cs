using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication1
{
    class Streamer
    {
        public static void ReadFile(List<Employee> students)
        {

            XmlWriterSettings sett = new XmlWriterSettings();

            sett.Indent = true;
            sett.IndentChars = " ";
            sett.NewLineChars = "\n";
            XmlWriter output = XmlWriter.Create("Base.xml", sett);
            output.WriteStartElement("Base");
            for (int i = 0; i < students.Count; i++)
            {
                output.WriteStartElement("Name", students[i].name);

                output.WriteElementString("Function", students[i].function);
                output.WriteElementString("Lvl", students[i].lvl.ToString());
                output.WriteElementString("Leadership",students[i].leadership.ToString());
                output.WriteElementString("Programming", students[i].programming.ToString());
                output.WriteElementString("Responsibility", students[i].responsibility.ToString());
                output.WriteElementString("Diplomacy", students[i].diplomacy.ToString());
                
                output.WriteEndElement();
            }
            output.WriteEndElement();
            output.Flush();
            output.Close();
        }

        public static void WriteFile(EmployeesBase BaseEmp)
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("Base.xml");
            
            foreach (XmlNode student in Doc.DocumentElement)
            {
                Employee stud = new Employee();
                stud.writeStudent(student.Attributes[0].Value, student["Function"].InnerText, int.Parse(student["Lvl"].InnerText),
                    int.Parse(student["Leadership"].InnerText), int.Parse(student["Programming"].InnerText), int.Parse(student["Responsibility"].InnerText),
                    int.Parse(student["Diplomacy"].InnerText));
                BaseEmp.employees.Add(stud);
                switch (student["Function"].InnerText)
                {
                    case "Product owner":
                        BaseEmp.ListPO.Add(stud);
                        break;
                    case "Scrum master":
                        BaseEmp.ListSM.Add(stud);
                        break;
                    case "Team":
                        BaseEmp.ListTeams.Add(stud);
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
}
