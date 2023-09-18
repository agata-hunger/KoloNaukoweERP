using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ZespolWydarzenie
    {
        [Key]
        public int ZespolWydarzenieId { get; set; }
        public int WydarzenieId { get; set; }
        public virtual Wydarzenie Wydarzenie { get; set; }

        public int ZespolId { get; set; }
        public virtual Zespol Zespol { get; set; }
    }
}
