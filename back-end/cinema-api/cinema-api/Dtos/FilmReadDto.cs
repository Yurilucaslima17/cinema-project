using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Dtos
{
    public class FilmReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Duration { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}
