using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CzlonekZespol
    {
        [Key]
        public int IdCzlonekZespol {get;set;}

        public int IdCzlonka {get; set;}
        [ForeignKey(nameof(IdCzlonka))]
        public Czlonek Czlonek { get; set;}

        public int IdZespolu { get; set;}
        [ForeignKey(nameof(IdZespolu))]
        public Zespol Zespol { get; set; }

/*        public ICollection<Czlonek> Czlonkowie { get; set; }
        public ICollection<Zespol> Zespoly { get; set; }*/
    }
}
