using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Projekt
    {
        [Key]
        public int IdProjektu { get; set; }

        public int IdZespolu { get; set; }
        [ForeignKey(nameof(IdZespolu))]
        public Zespol Zespol { get; set; }

        [MinLength(1, ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(50, ErrorMessage = "Nazwa jest za długa")]
        public string Nazwa { get; set; }

        public DateTime TerminRealizacji { get; set; }

        [MinLength(1, ErrorMessage = "Opis jest wymagany")]
        [MaxLength(300, ErrorMessage = "Opis jest za długi (max. 300 znaków)")]
        public string Opis { get; set; }

        //public ICollection<Zespol> Zespoly { get; set; }
    }
}
