using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PelnionaFunkcja
    {
        [Key]
        public int IdPelnionejFunkcji { get; set; }

        [MinLength(1, ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(50, ErrorMessage = "Nazwa jest za długa")]
        public string Nazwa { get; set; }

        public ICollection<Czlonek> Czlonkowie { get; set; }
    }
}
