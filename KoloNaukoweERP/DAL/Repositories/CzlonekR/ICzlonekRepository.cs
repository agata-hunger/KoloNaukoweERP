using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories.CzlonekR
{
    public interface ICzlonekRepository
    {
        IEnumerable<Czlonek> GetCzlonkowie();
        Czlonek GetCzlonekByID(int czlonekId);
        void InsertCzlonek(Czlonek czlonek);
        void DeleteCzlonek(int czlonekId);
        void UpdateCzlonek(Czlonek czlonek);
        void Save();
    }
}