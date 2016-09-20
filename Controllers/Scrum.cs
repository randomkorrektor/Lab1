using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Scrum
    {
        public BackLog productBL = new BackLog();
        public BackLog sprintBL = new BackLog();
        Random rand = new Random();
        public int work;
        public int reiterative = 0;
	

        public void GenerateProductBL(EmployeesBase empBase, Contract contract)
        {
            productBL.CreateProductBL(contract, empBase.staff[0]);
        }

        public void GenerateSprintBL(EmployeesBase empBase)
        {
            sprintBL.CreateSprintBL(productBL, empBase);
        }

        public void Sprint(EmployeesBase empBase)
        {
            work = empBase.employees[1].programming + empBase.employees[1].responsibility/2 + empBase.employees[0].leadership / 10 + empBase.employees[0].diplomacy
                / 10 + empBase.employees[2].responsibility / 10 + rand.Next(-30, 30) + reiterative;
        }
    }
}
