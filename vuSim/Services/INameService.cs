using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Services
{
    internal interface INameService
    {
        public string GetRandomFirstName();
        public string GetRandomLastName();

    }
}
