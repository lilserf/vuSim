using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class SubjectListing
    {
        internal static SubjectListing Instance;
        static SubjectListing()
        {
            Instance = new SubjectListing();
            // TODO
            Instance.AddSubject(new Subject("Math", "MAT"));
            Instance.AddSubject(new Subject("English", "ENG"));
            Instance.AddSubject(new Subject("Science", "SCI"));
            Instance.AddSubject(new Subject("Social Studies", "SOC"));
        }

        Dictionary<int, Subject> m_subjects = new Dictionary<int, Subject>();
        Random m_rand = new Random();

        internal void AddSubject(Subject subject)
        {
            m_subjects[subject.Id] = subject;
        }
        internal Subject GetSubjectById(int id)
        {
            return m_subjects[id];
        }

        internal Subject GetRandomSubject()
        {
            return m_subjects.Values.ElementAt(m_rand.Next(m_subjects.Values.Count));
        }
        
    }
}
