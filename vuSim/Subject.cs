using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim
{
    internal class Subject
    {
        public static string[] Names = new string[]
        {
            "Math",
            "Science",
            "English"
        };

        public static int Count => Names.Length;
    }
}
