using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Dtos
{
    public class RoomCreateDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public int QtnSeats { get; set; }
    }
}
