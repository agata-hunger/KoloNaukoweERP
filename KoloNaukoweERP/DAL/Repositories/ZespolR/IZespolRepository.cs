using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.ZespolR
{
    public interface IZespolRepository
    {
        IEnumerable<Zespol> GetZespoly();
        Zespol GetZespolById(int idZespolu);
        void InsertZespol(Zespol zespol);
        void DeleteZespol(int? idZespolu);
        void UpdateZespol(Zespol zespol);
        void InsertWydarzenie(int idZespolu, Wydarzenie wydarzenie);
        void DeleteWydarzenie(int idWydarzenia);
        void AddSprzet(int idZespolu, Sprzet sprzet);
        void DeleteSprzet(int idSprzetu);
        void InsertCzlonek(int idZespolu,  Czlonek czlonek);
        void DeleteCzlonek(int idczlonka);
        void Dispose();
        void Save();
    }
}
