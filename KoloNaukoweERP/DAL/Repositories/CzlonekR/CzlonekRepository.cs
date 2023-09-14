using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.CzlonekR
{
    public class CzlonekRepository : ICzlonekRepository
    {
        private DbKoloNaukoweERP context;

        public CzlonekRepository(DbKoloNaukoweERP context)
        {
            this.context = context;
        }

        public IEnumerable<Czlonek> GetCzlonkowie()
        {
            return context.Czlonkowie.ToList();
        }

        public Czlonek GetCzlonekById(int idCzlonka)
        {
            return context.Czlonkowie.Find(idCzlonka);
        }

        public void InsertCzlonek(Czlonek czlonek)
        {
            context.Czlonkowie.Add(czlonek);
        }

        public void DeleteCzlonek(int idCzlonka)
        {
            var czlonek = context.Czlonkowie.Find(idCzlonka);
            context.Czlonkowie.Remove(czlonek);
        }

        //TODO: fix/verify this method
        public void UpdateCzlonek(Czlonek czlonek)
        {
            context.Entry(czlonek).State = EntityState.Modified;
        }
        public void InsertWypozyczenie(int idCzlonka, Sprzet sprzet)
        {
            var czlonek = context.Czlonkowie.Find(idCzlonka);
            czlonek.Sprzety.Add(sprzet);
        }
        public void DeleteWypozyczenie(int idCzlonka, Sprzet sprzet)
        {

        }
        public void InsertPelnionaFunkcja(int idCzlonka, PelnionaFunkcja pelnionaFunkcja)
        {

        }
        public void DeletePelnionaFunkcja(int idCzlonka, PelnionaFunkcja pelnionaFunkcja)
        {

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
