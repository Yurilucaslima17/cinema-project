﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Model
{
    public class Section
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public bool Is3d { get; set; }

        [Required]
        public bool IsOriginal { get; set; }

        [Required]
        public virtual Film Film { get; set; }

        [Required]
        public virtual Room Room { get; set; }
    }
}
