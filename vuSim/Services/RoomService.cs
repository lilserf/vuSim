using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Services
{
    internal class RoomService : IRoomService
    {
        List<Room> m_rooms = new();
        public IEnumerable<Room> Rooms => m_rooms;

        public RoomService(IServiceProvider sp)
        {

        }
        public void AddRoom(Room room)
        {
            m_rooms.Add(room);
        }
    }
}
