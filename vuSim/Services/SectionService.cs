using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Services
{
    internal class SectionService : ISectionService
    {
        private List<Section> m_sections = new();
        public IEnumerable<Section> Sections => m_sections;

        private IRoomService m_roomService;
        private ITeacherService m_teacherService;
        public SectionService(IServiceProvider sp)
        {
            sp.Inject(out m_roomService);
            sp.Inject(out m_teacherService);
        }
        public void RecalculateSections()
        {
            m_sections.Clear();

            var subjects = m_roomService.Rooms.Select(x => x.Subject).Distinct();

            foreach (var subject in subjects)
            {
                var subjRooms = new Queue<Room>(m_roomService.Rooms.Where(x => x.Subject == subject).OrderByDescending(x => x.Seats));
                var subjTeachers = new Queue<Teacher>(m_teacherService.Teachers.Where(x => x.Subject == subject));

                while (subjRooms.Count > 0 && subjTeachers.Count > 0)
                {
                    m_sections.Add(new Section(subjTeachers.Dequeue(), subjRooms.Dequeue()));
                }
            }
        }
    }
}
