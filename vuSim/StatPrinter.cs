using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vuSim.Services;

namespace vuSim
{
    internal class StatPrinter
    {
        private IStudentService m_studentService;
        private ITeacherService m_teacherService;
        private ISectionService m_sectionService;
        private ISubjectService m_subjectService;
        private IRoomService m_roomService;
        public StatPrinter(IServiceProvider sp) 
        {
            sp.Inject(out m_studentService);
            sp.Inject(out m_teacherService);
            sp.Inject(out m_sectionService);
            sp.Inject(out m_subjectService);
            sp.Inject(out m_roomService);
        }

        public void PrintBasicStats(int term)
        {
            Console.WriteLine($"### STATS for term {term} ###");
            PrintSectionStats();
            PrintStudentStats();
            Console.WriteLine();
        }

        void PrintSectionStats()
        {
            var sections = m_sectionService.Sections;
            Console.WriteLine($"=== Sections ===");
            foreach(var subject in m_subjectService.Subjects)
            {
                var matchSec = sections.Where(x => x.Subject == subject);
                Console.WriteLine($"  {matchSec.Count()} sections of {subject.Name}, with {matchSec.Sum(x => x.Seats)} seats ({matchSec.Sum(x => x.OpenSeats)} open)");
            }
        }

        void PrintStudentStats()
        { 
            var fullStudents = m_studentService.Students.Count(x => x.Schedule.IsFull());
            var emptyStudents = m_studentService.Students.Count(x => x.Schedule.IsEmpty());
            var mixedStudents = m_studentService.Students.Count(x => !x.Schedule.IsEmpty() && !x.Schedule.IsFull());

            Console.WriteLine($"=== Students ===");
            Console.WriteLine($"  {fullStudents} fully scheduled");
            Console.WriteLine($"  {mixedStudents} partially scheduled");
            Console.WriteLine($"  {emptyStudents} not scheduled");
        }
    }
}
