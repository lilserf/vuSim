using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class Subject
    {
        static int MaxId = 0;
        public int Id { get; }
        public string Name { get; }
        public string ShortName { get; }

        public Subject(string name, string shortName)
        {
            Id = MaxId++;
            Name = name;
            ShortName = shortName;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
