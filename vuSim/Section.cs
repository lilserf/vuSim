using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class Section
    {
        public string Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Room Room { get; set; }

        public Section(Teacher teacher, Room room)
        {
            Teacher = teacher;
            Room = room;
            Subject = room.Subject;
        }

        public override string ToString()
        {
            return $"[{Subject}] in {Room}, taught by {Teacher}";
        }
    }
}
