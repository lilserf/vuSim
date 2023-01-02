using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vuSim.Services;

namespace vuSim
{
    internal class DegreeRequirements
    {
        IDictionary<Subject, int> Credits => m_credits;
        Dictionary<Subject, int> m_credits = new();
        
        internal static DegreeRequirements? General;

        private ISubjectService m_subjectService;
        public DegreeRequirements(IServiceProvider services) 
        {
            services.Inject(out m_subjectService);
        }

        internal Dictionary<Subject, int> GetMissingCredits(Transcript t)
        {
            Dictionary<Subject, int> diff = new();
            foreach(var (subj, hours) in m_credits)
            {
                if (t.Credits.ContainsKey(subj))
                {
                    diff[subj] = hours - t.Credits[subj];
                }
                else
                {
                    diff[subj] = hours;
                }

                // Remove 0-hour requirements
                if (diff[subj] == 0)
                {
                    diff.Remove(subj);
                }
            }

            return diff;
        }

        internal void AddRequirement(Subject s, int credits)
        {
            m_credits[s] = credits;
        }

        internal bool AreRequirementsMet(Transcript t)
        {
            var missing = GetMissingCredits(t);
            return missing.Count == 0;
        }

        public override string ToString()
        {
            var pairs = m_credits.Keys.Select(x => (x, m_credits[x])).ToList();

            return string.Join(", ", pairs.Select(x => $"{x.Item1}: {x.Item2}"));
        }
    }
}
