using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class Room
    {
        static int MaxId = 0;
        int Id { get; }
        public string Type { get; set; }
        public Subject Subject { get; set; } 
        public int Seats { get; set; }

        public Room(string type, Subject subject, int seats)
        {
            Id = MaxId++;
            Type = type;
            Subject = subject;
            Seats = seats;
        }

        public override string ToString()
        {
            return $"[{Id}] {Type} seating {Seats}";
        }
    }
}
