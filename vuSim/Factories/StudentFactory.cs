using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Factories
{
    internal class StudentFactory
    {

        public Student CreateStudent()
        {
            Student s = new Student(NameFactory.Instance.GetRandomFirstName(), NameFactory.Instance.GetRandomLastName());
            return s;
        }
    }
}
