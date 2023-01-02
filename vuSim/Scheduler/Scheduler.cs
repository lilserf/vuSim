using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class Scheduler
    {
        public Scheduler() { }

        public static bool TryScheduleStudent(Student student, IEnumerable<Section> sections)
        {
            var subjList = new Queue<Subject>(student.GetNeededSubjects());

            while (subjList.Count > 0)
            {
                var subj = subjList.Dequeue();
                // TODO randomly pick one of the sections with open seats rather than always choosing the first one
                Section? avail = sections.Where(x => x.Subject == subj).Where(x => x.OpenSeats > 0).FirstOrDefault();
                if (avail != null)
                {
                    student.ScheduleSection(avail);
                    avail.Students.Add(student);
                    if(student.Schedule.IsFull())
                        return true;
                }
            }
            return false;
        }
    }
}
