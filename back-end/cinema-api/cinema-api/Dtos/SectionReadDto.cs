using cinema_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Dtos
{
    public class SectionReadDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double Price { get; set; }

        public bool Is3d { get; set; }

        public bool IsOriginal { get; set; }

        public virtual Film Film { get; set; }

        public virtual Room Room { get; set; }
    }
}
