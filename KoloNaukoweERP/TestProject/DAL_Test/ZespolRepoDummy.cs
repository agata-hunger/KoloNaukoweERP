using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using DAL.Repositories.ZespolR;

namespace TestProject.DAL_Test
{
    public class ZespolRepoDummy : IZespolRepository
    {
        public void DeleteZespol(int? idZespolu)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Zespol GetZespolById(int idZespolu)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Zespol> GetZespoly()
        {
            throw new NotImplementedException();
        }

        public void InsertZespol(Zespol zespol)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateZespol(Zespol zespol)
        {
            throw new NotImplementedException();
        }

        public void InsertWydarzenie(int idZespolu, Wydarzenie wydarzenie)
        {

            throw new NotImplementedException();
        }
        public void DeleteWydarzenie(int idWydarzenia)
        {
            throw new NotImplementedException();
        }
        public void AddSprzet(int idZespolu, Sprzet sprzet)
        {
            throw new NotImplementedException();
        }

        public void DeleteSprzet(int idZespolu, Sprzet sprzet)
        {
            throw new NotImplementedException();
        }

        public void DeleteSprzet(int idSprzetu)
        {
            throw new NotImplementedException();
        }

        public void InsertCzlonek(int idZespolu, Czlonek czlonek)
        {
            throw new NotImplementedException();
        }

        public void DeleteCzlonek(int idczlonka)
        {
            throw new NotImplementedException();
        }
    }
}
