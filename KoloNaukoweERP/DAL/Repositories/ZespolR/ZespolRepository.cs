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
            return context.Zespoly.Find(idZespolu);
        }
        public void InsertZespol(Zespol zespol)
        {
            context.Zespoly.Add(zespol);
        }
        public void DeleteZespol(int? idZespolu)
        {
            var zespol = context.Zespoly.Find(idZespolu);
            context.Zespoly.Remove(zespol);
        }
        public void UpdateZespol(Zespol zespol)
        {
            context.Entry(zespol).State = EntityState.Modified;
        }
        public void InsertWydarzenie(int idZespolu, Wydarzenie wydarzenie)
        {
            var zespol = context.Zespoly.Find(idZespolu);
            zespol.Wydarzenia.Add(wydarzenie);
        }
        public void DeleteWydarzenie(int idZespolu, Wydarzenie wydarzenie)
        {
            var zespol = context.Zespoly.Find(idZespolu);
            zespol.Wydarzenia.Remove(wydarzenie);
        }
        public void InsertCzlonek(int idZespolu, Czlonek czlonek)
        {
            var zespol = context.Zespoly.Find(idZespolu);
            zespol.Czlonkowie.Add(czlonek);
        }
        public void DeleteCzlonek(int idZespolu, Czlonek czlonek)
        {
            var zespol = context.Zespoly.Find(idZespolu);
            zespol.Czlonkowie.Remove(czlonek);
        }
        public void AddSprzet(int idZespolu, Sprzet sprzet)
        {
            var zespol = context.Zespoly.Find(idZespolu);
            zespol.Sprzety.Add(sprzet);
        }
        public void DeleteSprzet(int idZespolu, Sprzet sprzet)
        {
            var zespol = context.Zespoly.Find(idZespolu);
            zespol.Sprzety.Remove(sprzet);
        }
        public void InsertProjekt(int idZespolu, Projekt projekt)
        {
            var zespol = context.Zespoly.Find(idZespolu);
            zespol.Projekty.Add(projekt);
        }
        public void DeleteProjekt(int idZespolu, Projekt projekt)
        {
            var zespol = context.Zespoly.Find(idZespolu);
            zespol.Projekty.Remove(projekt);
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
