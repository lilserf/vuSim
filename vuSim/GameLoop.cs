using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vuSim.Services;

namespace vuSim
{
    internal class GameLoop
    {
  

        ITeacherService m_teacherService;
        IStudentService m_studentService;
        ISectionService m_sectionService;
        ITimeService m_timeService;

        public GameLoop(IServiceProvider services)
        {
            services.Inject(out m_teacherService);
            services.Inject(out m_studentService);
            services.Inject(out m_sectionService);
            services.Inject(out m_timeService);
        }

        public void ExecuteStartOfTerm()
        {
            m_timeService.AdvanceTerm();

            m_sectionService.RecalculateSections();

            foreach (var student in m_studentService.Students)
            {
                Scheduler.TryScheduleStudent(student, m_sectionService.Sections);
            }
        }

        public void TickTerm() 
        {
            m_timeService.TickTerm();
        }

        public void ExecuteEndOfTerm()
        {
            List<Student> graduates = new();

            foreach(var student in m_studentService.Students)
            {
                student.FinishTerm();
                if(student.IsDegreeEarned())
                {
                    graduates.Add(student);
                }
            }

            foreach (var student in graduates)
            {
                m_studentService.GraduateStudent(student);
            }
        }
    }
}
