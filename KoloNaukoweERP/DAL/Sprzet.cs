using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Sprzet
    {
        [Key]
        public int IdSprzetu { get; set; }

        public int IdCzlonka { get; set; }
        [ForeignKey(nameof(IdCzlonka))]
        public Czlonek? Czlonek { get; set; } 

        public int IdZespolu { get; set; }
        [ForeignKey(nameof(IdZespolu))]
        public Zespol? Zespol { get; set; }

        [MinLength(1, ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(50, ErrorMessage = "Nazwa jest za długa")]
        public string Nazwa { get; set; }

        [MinLength(1, ErrorMessage = "Opis jest wymagany")]
        [MaxLength(300, ErrorMessage = "Opis jest za długi (max. 300 znaków)")]
        public string Opis { get; set; }

        public bool CzyDostepny { get; set; }
    }
}
