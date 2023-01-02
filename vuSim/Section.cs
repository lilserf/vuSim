using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class Section
    {
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Room Room { get; set; }

        public IList<Student> Students { get; set; }

        public int Seats => Room.Seats;
        public int OpenSeats => Room.Seats - Students.Count;
        public Section(Teacher teacher, Room room)
        {
            Teacher = teacher;
            Room = room;
            Subject = room.Subject;
            Students = new List<Student>();
        }

        public override string ToString()
        {
            return $"{Subject} in {Room}, taught by {Teacher}";
        }
    }
}
