using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Dtos
{
    public class RoomReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int QtnSeats { get; set; }
    }
}
