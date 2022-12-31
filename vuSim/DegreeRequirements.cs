using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class DegreeRequirements
    {
        internal static DegreeRequirements General;

        static DegreeRequirements()
        {
            General = new DegreeRequirements();
            // TODO this is stupid
            General.AddRequirement(SubjectListing.Instance.GetSubjectById(0), 4);
            General.AddRequirement(SubjectListing.Instance.GetSubjectById(1), 4);
            General.AddRequirement(SubjectListing.Instance.GetSubjectById(2), 4);
            General.AddRequirement(SubjectListing.Instance.GetSubjectById(3), 4);

        }

        Dictionary<int, int> m_credits = new Dictionary<int, int>();

        public DegreeRequirements() 
        {
            
        }

        void AddRequirement(Subject s, int credits)
        {
            m_credits[s.Id] = credits;
        }

        internal bool AreRequirementsMet(Transcript t)
        {
            return false;
        }

        internal Subject GetNeededSubject(Transcript t, StudentSchedule ss)
        {
            // TODO: based on transcript and schedule, return a subject we need
            return SubjectListing.Instance.GetSubjectById(m_credits.Keys.First());
        }

        public override string ToString()
        {
            var subjects = m_credits.Keys.Select(x => SubjectListing.Instance.GetSubjectById(x));
            var pairs = subjects.Select(x => (x, m_credits[x.Id])).ToList();

            return string.Join(", ", pairs.Select(x => $"{x.Item1}: {x.Item2}"));
        }
    }
}
