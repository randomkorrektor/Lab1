using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    
    class EmployeesBase
    {
        public List<Employee> staff = new List<Employee>();
        public List<Employee> ListPO = new List<Employee>();
        public List<Employee> ListTeams = new List<Employee>();
        public List<Employee> ListSM = new List<Employee>();

        public void AddEmployee(string name, string function)
        {
            staff.Add(new Employee());
            staff[staff.Count-1].InitStudent(name, function);
            switch (function)
                {
                    case "Product owner":
                        ListPO.Add(staff[staff.Count - 1]);
                        break;
                    case "Scrum master":
                        ListSM.Add(staff[staff.Count - 1]);
                        break;
                    case "Team":
                        ListTeams.Add(staff[staff.Count - 1]);
                        break;
                    default:
                        break;
                }
        }

        public void DelEmployee(int index)
        {
            var obj = staff[index];
            staff.Remove(obj);
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

    }
}
