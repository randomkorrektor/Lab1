using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class BackLog
    {
        public int workload,timeLimit;

        public void CreateProductBL(Contract contract, Employee PO)
        {
            this.workload = contract.workload - PO.leadership - PO.programming;
            this.timeLimit = contract.timeLimit + PO.diplomacy / 5;
        }

        public void CreateSprintBL(BackLog productBL, EmployeesBase EmpBase)
        {
            this.timeLimit = EmpBase.sprinttimelimit;
            this.workload = productBL.workload / (productBL.timeLimit / EmpBase.sprinttimelimit + EmpBase.sprinttimelimit);
        }
    }
}
