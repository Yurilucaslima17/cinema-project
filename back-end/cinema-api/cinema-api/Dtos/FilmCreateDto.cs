﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Dtos
{
    public class FilmCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
