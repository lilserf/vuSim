using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vuSim.Services;

namespace vuSim
{
    internal class Student
    {
        static int MaxId = 0;
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => $"{FirstName} {LastName}";
        public Transcript Transcript { get; set; }
        public StudentSchedule Schedule { get; set; }
        public DegreeRequirements DegreeRequirements { get; set; }
        public int TermsEnrolled { get; set; }

        public Student(string firstName, string lastName)
        {
            Id = MaxId++;
            FirstName = firstName;
            LastName = lastName;
            Transcript = new Transcript();
            Schedule = new StudentSchedule();
            DegreeRequirements = DegreeRequirements.General;
            TermsEnrolled = 0;
        }

        public IEnumerable<Subject> GetNeededSubjects()
        {
            return DegreeRequirements.GetMissingCredits(Transcript).OrderByDescending(x => x.Value).Select(x => x.Key).ToList();
        }

        public void ScheduleSection(Section s)
        {
            Schedule.Sections.Add(s);
        }

        public void FinishTerm()
        {
            // Don't bother if they weren't in any classes
            // TODO: future features here
            if (Schedule.IsEmpty())
                return;

            TermsEnrolled++;
            foreach (var section in Schedule.Sections)
            {
                Transcript.AddCompletedCredit(section);
            }
            Schedule.Clear();
        }

        public bool IsDegreeEarned()
        {
            return DegreeRequirements.AreRequirementsMet(Transcript);
        }

        public override string ToString()
        {
            return $"[S{Id}] {FirstName} {LastName}";
        }
    }
}
