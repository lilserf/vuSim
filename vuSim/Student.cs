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
        public string Name => $"{FirstName} {LastName}";
        public Transcript Transcript { get; set; }
        public StudentSchedule Schedule { get; set; }
        public DegreeRequirements DegreeRequirements { get; set; }

        private Subject TopSubject;
        public Student(string firstName, string lastName)
        {
            Id = MaxId++;
            FirstName = firstName;
            LastName = lastName;
            Transcript = new Transcript();
            Schedule = new StudentSchedule();
            DegreeRequirements = new DegreeRequirements();

            Random r = new Random();
            TopSubject = SubjectListing.Instance.GetRandomSubject();
        }

        public Subject GetTopSubject()
        {
            return TopSubject;
        }

        public void ScheduleSection(Section s)
        {
            Schedule.Sections.Add(s);
        }

        public override string ToString()
        {
            return $"[S{Id}] {FirstName} {LastName}";
        }
    }
}
