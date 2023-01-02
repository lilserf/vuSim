using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class DegreeRequirements
    {
        Dictionary<int, int> Credits => m_credits;
        Dictionary<int, int> m_credits = new();
        
        internal static DegreeRequirements General;

        static DegreeRequirements()
        {
            General = new DegreeRequirements();
            // TODO this is stupid, hardcoding these
            General.AddRequirement(SubjectListing.Instance.GetSubjectById(0), 4);
            General.AddRequirement(SubjectListing.Instance.GetSubjectById(1), 4);
            General.AddRequirement(SubjectListing.Instance.GetSubjectById(2), 4);
            General.AddRequirement(SubjectListing.Instance.GetSubjectById(3), 4);

        }

        public DegreeRequirements() 
        {
            
        }

        internal Dictionary<int, int> GetMissingCredits(Transcript t)
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

        internal void AddRequirement(Subject s, int credits)
        {
            m_credits[s.Id] = credits;
        }

        internal bool AreRequirementsMet(Transcript t)
        {
            var missing = GetMissingCredits(t);
            return missing.Count == 0;
        }

        public override string ToString()
        {
            var subjects = m_credits.Keys.Select(x => SubjectListing.Instance.GetSubjectById(x));
            var pairs = subjects.Select(x => (x, m_credits[x.Id])).ToList();

            return string.Join(", ", pairs.Select(x => $"{x.Item1}: {x.Item2}"));
        }
    }
}
