using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vuSim.Services;

namespace vuSim.Factories
{
    internal class StudentFactory
    {

        public Student CreateStudent()
        {
            Student s = new Student(NameService.Instance.GetRandomFirstName(), NameService.Instance.GetRandomLastName());
            return s;
        }
    }
}
