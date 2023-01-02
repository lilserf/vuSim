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
        public int TermsEnrolled { get; private set; } = 0;

        public EventLog Events { get; }

        public Student(IServiceProvider sp, string firstName, string lastName)
        {
            Id = MaxId++;
            FirstName = firstName;
            LastName = lastName;
            Transcript = new Transcript();
            Schedule = new StudentSchedule();
            DegreeRequirements = DegreeRequirements.General;

            Events = new(sp);
        }

        public IEnumerable<Subject> GetNeededSubjects()
        {
            return DegreeRequirements.GetMissingCredits(Transcript).OrderByDescending(x => x.Value).Select(x => x.Key).ToList();
        }

        public void ScheduleSection(Section s)
        {
            Schedule.Sections.Add(s);
            Events.Add($"Scheduled for section {s}");
        }

        public void FinishTerm()
        {
            // Don't bother if they weren't in any classes
            // TODO: future features here
            if (Schedule.IsEmpty())
                return;

            TermsEnrolled++;
            Events.Add($"TermsEnrolled now {TermsEnrolled}");
            foreach (var section in Schedule.Sections)
            {
                Transcript.AddCompletedCredit(section);
                Events.Add($"Completed credit in {section.Subject}");
            }
            Schedule.Clear();
        }

        public void Graduate()
        {
            Events.Add($"Graduated successfully!");
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
