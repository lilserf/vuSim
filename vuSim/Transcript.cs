using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class Transcript
    {
        public Transcript() { }

        public Dictionary<Subject, int> Credits => m_credits;
        Dictionary<Subject, int> m_credits = new();

        public void AddCompletedCredit(Section section)
        {
            if(!Credits.ContainsKey(section.Subject))
            {
                Credits[section.Subject] = 0;
            }
            Credits[section.Subject] += 1;
        }
    }
}
