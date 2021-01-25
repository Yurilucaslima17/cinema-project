using cinema_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Data
{
    public interface IRoomRepo
    {
        IEnumerable<Room> GetAllRooms();
        Room GetRoomById(int Id);
        IEnumerable<Section> GetAllSectionsOnRoom(int Id);
    }
}
