using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Scheduler
{
    internal class Scheduler
    {
        public Scheduler() { }

        public static IEnumerable<Section> CreateSections(IEnumerable<Room> rooms, IEnumerable<Teacher> teachers)
        {
            var subjects = rooms.Select(x => x.Subject).Distinct();

            foreach(var subject in subjects)
            {
                var subjRooms = new Queue<Room>(rooms.Where(x => x.Subject == subject).OrderByDescending(x => x.Seats));
                var subjTeachers = new Queue<Teacher>(teachers.Where(x => x.Subject == subject));

                while(subjRooms.Count > 0 && subjTeachers.Count > 0)
                {
                    yield return new Section(subjTeachers.Dequeue(), subjRooms.Dequeue());
                }
            }
        }
    }
}
