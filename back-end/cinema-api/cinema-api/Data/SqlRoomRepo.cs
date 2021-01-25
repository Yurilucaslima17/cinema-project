using cinema_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Data
{
    public class SqlRoomRepo : IRoomRepo
    {
        private readonly CinemaContext _context;

        public SqlRoomRepo(CinemaContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public IEnumerable<Section> GetAllSectionsOnRoom(int Id)
        {
            return _context.Sections.Where(p => p.Room.Id == Id);
        }

        public Room GetRoomById(int Id)
        {
            return _context.Rooms.FirstOrDefault(p => p.Id == Id);
        }

    }
}
