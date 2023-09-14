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

        public Wydarzenie GetWydarzenieById(int? idWydarzenia)
        {
            return context.Wydarzenia.Find(idWydarzenia);
        }

        public void InsertWydarzenie(Wydarzenie wydarzenie)
        {
            context.Wydarzenia.Add(wydarzenie);
        }

        public void DeleteWydarzenie(int idWydarzenia)
        {
            var wydarzenie = context.Wydarzenia.Find(idWydarzenia);
            context.Wydarzenia.Remove(wydarzenie);
        }

        public void UpdateWydarzenie(Wydarzenie wydarzenie)
        {
            context.Entry(wydarzenie).State = EntityState.Modified;
        }

        public void InsertZespol(int idWydarzenia, Zespol zespol)
        {
            var wydarzenie = context.Wydarzenia.Find(idWydarzenia);
            context.Zespoly.Add(zespol);
        }

        public void DeleteZespol(int idWydarzenia, Zespol zespol)
        {
            var wydarzenie = context.Wydarzenia.Find(idWydarzenia);
            context.Zespoly.Remove(zespol);
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
