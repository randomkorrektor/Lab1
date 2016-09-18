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
        public void ReadFile(List<Student> students)
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

        public void WriteFile(List<Student> students)
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("Base.xml");
            
            /*foreach (XmlNode student in Doc.GetElementsByTagName("Name"))
            {
                if (student.Attributes["xmlns"] == null)
                    continue;*/

            foreach (XmlNode student in Doc.DocumentElement)
            {
                Student stud = new Student();
                stud.ReadStudent(student.Attributes[0].Value, student["Function"].InnerText, int.Parse(student["Lvl"].InnerText),
                    int.Parse(student["Leadership"].InnerText), int.Parse(student["Programming"].InnerText), int.Parse(student["Responsibility"].InnerText),
                    int.Parse(student["Diplomacy"].InnerText));
                students.Add(stud);
                    

                /*foreach (XmlNode student in Doc.DocumentElement.ChildNodes)
                Point[] pointsarray = new Point[student.ChildNodes.Count / 2];
                VectorOfPoint vectforread = new VectorOfPoint();
                int s = 0;
                for (int i = 0; i < student.ChildNodes.Count - 1; i += 2)
                {
                    pointsarray[s].X = Convert.ToInt32(student.ChildNodes.Item(i).InnerText);
                    pointsarray[s].Y = Convert.ToInt32(student.ChildNodes.Item(i + 1).InnerText);
                    s++;
                }
                vectforread.Push(pointsarray);
                Alphabet.Add(new Letter(student.NamespaceURI, vectforread));
                 */
            }
            
        }
    }
}
