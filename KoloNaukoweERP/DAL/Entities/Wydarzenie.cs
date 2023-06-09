﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Wydarzenie
    {
        [Key]
        public int IdWydarzenia { get; set; }

        public int? IdZespolu { get; set; }
        [ForeignKey(nameof(IdZespolu))]
        public Zespol? Zespol { get; set; }

        [MinLength(1, ErrorMessage = "Nazwa wydarzenia jest wymagana")]
        [MaxLength(50, ErrorMessage = "Nazwa wydarzenia jest za długa")]
        public string Nazwa { get; set; }

        public DateTime Data { get; set; }

        [MinLength(1, ErrorMessage = "Nazwa miejsca jest wymagana")]
        [MaxLength(50, ErrorMessage = "Nazwa miejsca jest za długa")]
        public string Miejsce { get; set; }
    }
}
