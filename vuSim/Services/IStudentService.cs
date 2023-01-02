using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Services
{
    internal interface IStudentService
    {
        public IEnumerable<Student> Students { get; }

        public Student CreateNewStudent();
    }
}
