using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ZespolProjekt
    {
        public int ProjektId { get; set; }
        public virtual Projekt Projekt { get; set; }

        public int ZespolId { get; set; }
        public virtual Zespol Zespol { get; set; }
    }
}
