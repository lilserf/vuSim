using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vuSim.Services;

namespace vuSim
{
    internal class EventLog
    {
        private List<(int, int, string)> m_events = new();
        public IEnumerable<(int, int, string)> Events => m_events;

        private ITimeService m_timeService;

        public EventLog(IServiceProvider sp)
        {
            sp.Inject(out m_timeService);
        }
        public void Add(string info)
        {
            m_events.Add((m_timeService.Term, m_timeService.Tick, info));
        }
    }
}
