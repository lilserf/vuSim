using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Services
{
    internal class TimeService : ITimeService
    {
        public int Term { get; private set; } = 0;
        public int Tick { get; private set; } = 0;

        public void AdvanceTerm()
        {
            Term++;
            Tick = 0;
        }

        public void TickTerm()
        {
            Tick++;
        }
    }
}
