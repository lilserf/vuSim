using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class StudentSchedule
    {
        const int MAX_SECTIONS_PER_TERM = 4;
        public IList<Section> Sections { get; set; }

        public StudentSchedule()
        {
            Sections = new List<Section>();
        }

        public bool IsFull()
        {
            return Sections.Count >= MAX_SECTIONS_PER_TERM;
        }
        public bool IsEmpty()
        {
            return Sections.Count == 0;
        }

        public override string ToString()
        {
            return string.Join("| ", Sections);
        }
    }
}
