using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class DegreeRequirements
    {
        Dictionary<string, int> m_credits= new Dictionary<string, int>();

        public DegreeRequirements() 
        {
            
        }

        bool AreRequirementsMet(Transcript t)
        {
            return false;
        }


    }
}
