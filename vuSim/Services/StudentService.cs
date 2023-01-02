using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Services
{
    internal class StudentService : IStudentService
    {
        List<Student> m_students = new();
        public IEnumerable<Student> Students => m_students;

        private INameService m_nameService;
        public StudentService(IServiceProvider services)
        {
            services.Inject(out m_nameService);
        }

        public Student CreateNewStudent()
        {
            Student s = new Student(m_nameService.GetRandomFirstName(), m_nameService.GetRandomLastName());
            m_students.Add(s);
            return s;
        }
    }
}
