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


    }
}
