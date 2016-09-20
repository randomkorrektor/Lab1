using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class BackLog
    {
        public int workload, timeLimit, POWorkload, POTime;
        Random rand = new Random();
        

        public void CreateProductBL(Contract contract, Employee PO)
        {
            POWorkload = PO.leadership + PO.programming + rand.Next(-5, 5);
            POTime = PO.diplomacy / 5 + rand.Next(-5, 5);
            this.workload = contract.workload - POWorkload;
            this.timeLimit = contract.timeLimit + POTime;
        }

        public void CreateSprintBL(BackLog productBL, EmployeesBase EmpBase)
        {
            this.timeLimit = EmpBase.sprinttimelimit;
            this.workload = productBL.workload / (productBL.timeLimit / EmpBase.sprinttimelimit + 1);
        }
    }
}
