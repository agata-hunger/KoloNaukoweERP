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
        Czlonek GetCzlonekById(int idCzlonka);
        void InsertCzlonek(Czlonek czlonek);
        void DeleteCzlonek(int idCzlonka);
        void UpdateCzlonek(Czlonek czlonek);
        void InsertWypozyczenie(int idCzlonka, Sprzet sprzet);
        void DeleteWypozyczenie(int idCzlonka, Sprzet sprzet);
        void Dispose();
        void Save();
    }
}