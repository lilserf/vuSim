using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Services
{
    internal class SubjectService : ISubjectService
    {
        Dictionary<int, Subject> m_subjects = new Dictionary<int, Subject>();
        Random m_rand = new Random();

        public void AddSubject(Subject subject)
        {
            m_subjects[subject.Id] = subject;
        }
        public Subject GetSubjectById(int id)
        {
            return m_subjects[id];
        }

        public Subject GetRandomSubject()
        {
            return m_subjects.Values.ElementAt(m_rand.Next(m_subjects.Values.Count));
        }

    }
}
