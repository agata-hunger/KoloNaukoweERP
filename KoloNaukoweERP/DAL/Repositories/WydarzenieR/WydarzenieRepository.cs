using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.WydarzenieR
{
    public class WydarzenieRepository : IWydarzenieRepository
    {
        private DbKoloNaukoweERP context;

        public WydarzenieRepository(DbKoloNaukoweERP context)
        {
            this.context = context;
        }
        public IEnumerable<Wydarzenie> GetWydarzenia()
        {
            return context.Wydarzenia.ToList();
        }
        public Wydarzenie GetWydarzenieById(int idWydarzenia)
        {
            return context.Wydarzenia.Find(idWydarzenia);
            
        }
        public void InsertWydarzenie(Wydarzenie wydarzenie)
        {
            context.Wydarzenia.Add(wydarzenie);
        }
        public void DeleteWydarzenie(int? idWydarzenia)
        {
            Wydarzenie wydarzenie = context.Wydarzenia.Find(idWydarzenia);
            context.Wydarzenia.Remove(wydarzenie);
        }
        public void UpdateWydarzenie(Wydarzenie wydarzenie)
        {
            context.Entry(wydarzenie).State = EntityState.Modified;
        }
        public void InsertZespol(int idWydarzenia, Zespol zespol)
        {
            throw new NotImplementedException();
        }
        public void DeleteZespol(int idWydarzenia, Zespol zespol)
        {
            throw new NotImplementedException();
        }
        public void RemovePelnionaFunkcja(int idPelnionejFunkcji)
        {
            throw new NotImplementedException();
        }
        public void RemovePelnionaFunkcjaFromUser(int idCzlonka, PelnionaFunkcja pelnionaFunkcja)
        {
            throw new NotImplementedException();
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
