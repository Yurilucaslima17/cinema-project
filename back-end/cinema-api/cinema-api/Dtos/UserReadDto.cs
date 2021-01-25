using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Dtos
{
    public class UserReadDto
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
