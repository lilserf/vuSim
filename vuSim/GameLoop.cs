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
        int m_currTerm = 0;
        int m_currTick = 0;

        ITeacherService m_teacherService;
        IStudentService m_studentService;
        ISectionService m_sectionService;

        public GameLoop(IServiceProvider services)
        {
            services.Inject(out m_teacherService);
            services.Inject(out m_studentService);
            services.Inject(out m_sectionService);
        }

        public int ExecuteStartOfTerm()
        {
            m_currTerm++;
            m_currTick = 0;

            m_sectionService.RecalculateSections();

            foreach (var student in m_studentService.Students)
            {
                Scheduler.TryScheduleStudent(student, m_sectionService.Sections);
            }

            return m_currTerm;
        }

        public void TickTerm() 
        {
            m_currTick++;
        }

        public void ExecuteEndOfTerm()
        {

        }
    }
}
