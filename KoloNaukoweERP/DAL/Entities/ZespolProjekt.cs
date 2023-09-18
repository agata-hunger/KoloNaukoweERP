using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ZespolProjekt
    {
        [Key]
        public int ZespolProjektId { get; set; }
        public int ProjektId { get; set; }
        public virtual Projekt Projekt { get; set; }

        public int ZespolId { get; set; }
        public virtual Zespol Zespol { get; set; }
    }
}
