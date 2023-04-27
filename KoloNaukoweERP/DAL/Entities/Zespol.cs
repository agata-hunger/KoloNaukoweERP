using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Zespol
    {
        [Key]
        public int IdZespolu { get; set; }

        [MinLength(1, ErrorMessage = "Nazwa zespołu jest wymagana")]
        [MaxLength(50, ErrorMessage = "Nazwa zespołu jest za długa")]
        public string Nazwa { get; set; }

        public ICollection<Czlonek> Czlonkowie { get; set; }
        public ICollection<Sprzet> Sprzety { get; set; }
        public ICollection<Projekt> Projekty { get; set; }
        public ICollection<Wydarzenie> Wydarzenia { get; set; }
    }
}
