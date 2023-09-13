using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.ZespolR
{
    public class ZespolRepository : IZespolRepository
    {
        private DbKoloNaukoweERP context;

        public ZespolRepository(DbKoloNaukoweERP context)
        {
            this.context = context;
        }
        public IEnumerable<Zespol> GetZespoly()
        {
            return context.Zespoly.ToList();
        }
        public Zespol GetZespolById(int idZespolu)
        {
            /*Zespol zespol = context.Zespoly.Find(idZespolu);
            return zespol;*/
            
            return context.Zespoly.Find(idZespolu);
        }
        public void InsertZespol(Zespol zespol)
        {
            context.Zespoly.Add(zespol);
        }
        public void DeleteZespol(int? idZespolu)
        {
            Zespol zespol = context.Zespoly.Find(idZespolu);
            context.Zespoly.Remove(zespol);
        }
        public void UpdateZespol(Zespol zespol)
        {
            context.Entry(zespol).State = EntityState.Modified;
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void InsertWydarzenie(int idZespolu, Wydarzenie wydarzenie)
        {
            Zespol zespol = context.Zespoly.Find(idZespolu);
            zespol.Wydarzenia.Add(wydarzenie);
        }
        public void DeleteWydarzenie(int idWydarzenia)
        {
            throw new NotImplementedException();
        }

        public void AddSprzet(int idZespolu, Sprzet sprzet)
        {
            Zespol zespol = context.Zespoly.Find(idZespolu);
            zespol.Sprzety.Add(sprzet);
        }
        public void DeleteSprzet(int idSprzetu)
        {
            throw new NotImplementedException();
        }

        public void InsertCzlonek(int idZespolu, Czlonek czlonek)
        {
            Zespol zespol = context.Zespoly.Find(idZespolu);
            zespol.Czlonkowie.Add(czlonek);
        }

        public void DeleteCzlonek(int idczlonka)
        {
            throw new NotImplementedException();
            /////
        }

        public void InsertProjekt(int idZespolu, Projekt projekt)
        {
            Zespol zespol = context.Zespoly.Find(idZespolu);
            zespol.Projekty.Add(projekt);
        }

        public void DeleteProjekt(int idProjektu)
        {
            throw new NotImplementedException();
        }
    }
}
