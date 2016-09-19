using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ContractsBase
    {
        public List<Contract> contracts= new List<Contract>();
        public int acceptID;

        public void CreateContract(string name, string specification, int workload, int timeLimit)
        {
            contracts.Add(new Contract(name, specification, workload,timeLimit));
        }

        public void DeleteContract(int index)
        {
            contracts.Remove(contracts[index]);
        }


    }
}
