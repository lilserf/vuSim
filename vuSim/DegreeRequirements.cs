using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class DegreeRequirements
    {
        Dictionary<int, int> m_credits = new();

        public DegreeRequirements() 
        {
            
        }

        Dictionary<int, int> GetMissingCredits(Transcript t)
        {
            Dictionary<int, int> diff = new();
            foreach(var (subjId, hours) in m_credits)
            {
                if (t.Credits.ContainsKey(subjId))
                {
                    diff[subjId] = hours - t.Credits[subjId];
                }
                else
                {
                    diff[subjId] = hours;
                }

                // Remove 0-hour requirements
                if (diff[subjId] == 0)
                {
                    diff.Remove(subjId);
                }
            }

            return diff;
        }

        bool AreRequirementsMet(Transcript t)
        {
            var missing = GetMissingCredits(t);
            return missing.Count == 0;
        }


    }
}
