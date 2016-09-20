using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Contract
    //Public?
    {

        protected string _name, _specification;
        protected int _workload, _timeLimit;
        public string name { get { return _name; } }
        public string specification { get { return _specification; } }
        public int workload { get { return _workload; } }
        public int timeLimit { get { return _timeLimit; } }


        public Contract(string name, string specification, int workload, int timeLimit)
        {
            this._name = name;
            this._specification = specification;
            this._workload = workload;
            this._timeLimit = timeLimit;
        }


        public string GetData()
        {
            return ("Name: " + this.name + "\n" + "Workload: " + this.workload.ToString() + "\n" + "Time limit: " + this.timeLimit.ToString());
        }
    }
}
