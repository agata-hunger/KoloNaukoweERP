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
        void DeleteWydarzenie(int idZespolu, Wydarzenie wydarzenie);
        void InsertCzlonek(int idZespolu, Czlonek czlonek);
        void DeleteCzlonek(int idZespolu, Czlonek czlonek);
        void AddSprzet(int idZespolu, Sprzet sprzet);
        void DeleteSprzet(int idZespolu, Sprzet sprzet);
        void InsertProjekt(int idZespolu, Projekt projekt);
        void DeleteProjekt(int idZespolu, Projekt projekt);
        void Dispose();
        void Save();
    }
}
