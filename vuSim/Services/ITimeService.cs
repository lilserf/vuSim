using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Services
{
    internal interface ITimeService
    {
        public int Term { get; }
        public int Tick { get; }

        public void AdvanceTerm();
        public void TickTerm();
    }
}
