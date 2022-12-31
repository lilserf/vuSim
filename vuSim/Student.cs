using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class Student
    {
        static int MaxId = 0;
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Transcript Transcript { get; set; }
        public StudentSchedule Schedule { get; set; }
        public DegreeRequirements DegreeRequirements { get; set; }

        private string TopSubject;
        public Student(string firstName, string lastName)
        {
            Id = MaxId++;
            FirstName = firstName;
            LastName = lastName;
            Transcript = new Transcript();
            Schedule = new StudentSchedule();
            DegreeRequirements = new DegreeRequirements();

            Random r = new Random();
            TopSubject = Subject.Names[r.Next(Subject.Count)];
        }

        public string GetTopSubject()
        {
            return TopSubject;
        }

        public void ScheduleSection(Section s)
        {
            Schedule.Sections.Add(s);
        }

        public override string ToString()
        {
            return $"[S{Id}] {FirstName} {LastName}, interested in {TopSubject}";
        }
    }
}
