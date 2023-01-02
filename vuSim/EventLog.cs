using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class EventLog
    {
        private List<(int, int, string)> m_events = new();
        public IEnumerable<(int, int, string)> Events => m_events;

        public void Add(int term, int tick, string info)
        {
            m_events.Add((term, tick, info));
        }
    }
}
