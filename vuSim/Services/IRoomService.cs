using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Services
{
    internal interface IRoomService
    {
        public IEnumerable<Room> Rooms { get; }
    }
}
