using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    
    public class EmployeesBase
        //Public?
    {
        public List<Employee> employees = new List<Employee>();
        public List<Employee> ListPO = new List<Employee>();
        public List<Employee> ListTeams = new List<Employee>();
        public List<Employee> ListSM = new List<Employee>();
        public List<Employee> staff = new List<Employee>();
        public int sprinttimelimit;
        


        public void AddEmployee(string name, string function)
        {
            employees.Add(new Employee());
            employees[employees.Count-1].InitStudent(name, function);
            switch (function)
                {
                    case "Product owner":
                        ListPO.Add(employees[employees.Count - 1]);
                        break;
                    case "Scrum master":
                        ListSM.Add(employees[employees.Count - 1]);
                        break;
                    case "Team":
                        ListTeams.Add(employees[employees.Count - 1]);
                        break;
                    default:
                        break;
                }
        }

        public void DelEmployee(int index)
        {
            var obj = employees[index];
            employees.Remove(obj);
            switch (obj.function)
            {
                case "Product owner":
                    ListPO.Remove(obj);
                    break;
                case "Scrum master":
                    ListSM.Remove(obj);
                    break;
                case "Team":
                    ListTeams.Remove(obj);
                    break;
                default:
                    break;
            }
        }

        public void AlterFuncEmployee(int index, string func)
        {
            var obj = employees[index];
            switch (obj.function)
            {
                case "Product owner":
                    ListPO.Remove(obj);
                    break;
                case "Scrum master":
                    ListSM.Remove(obj);
                    break;
                case "Team":
                    ListTeams.Remove(obj);
                    break;
                default:
                    break;
            }
            obj.AlterFunc(func);
            switch (func)
            {
                case "Product owner":
                    ListPO.Add(obj);
                    break;
                case "Scrum master":
                    ListSM.Add(obj);
                    break;
                case "Team":
                    ListTeams.Add(obj);
                    break;
                default:
                    break;
            }

        }

        public void BuildStaff(int indexPO, int indexTeam, int indexSM, int time)
        {
            staff.Clear();
            staff.Add(ListPO[indexPO]);
            staff.Add(ListTeams[indexTeam]);
            staff.Add(ListSM[indexSM]);
            sprinttimelimit = time;
        }
    }
}
