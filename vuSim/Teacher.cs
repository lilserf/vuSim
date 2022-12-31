using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class Teacher
    {
        static int MaxId = 0;
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public Teacher(string firstName, string lastName, string subject)
        {
            Id = MaxId++;
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
        }

        public override string ToString()
        {
            return $"[T{Id}] {FirstName} {LastName}";
        }
    }
}
